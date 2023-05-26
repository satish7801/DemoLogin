using DemoLogin.DTO;
using DemoLogin.Enum;
using DemoLogin.Models.Data;
using DemoLogin.Models.Models;
using DemoLogin.Repository.Interface;
using System.Security.Cryptography;
using System.Text;

namespace DemoLogin.Repository.Repository
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        private readonly CiPlatformContext _ciPlatformContext;

        public AuthRepository(CiPlatformContext ciPlatformContext):base(ciPlatformContext)
        {
                _ciPlatformContext = ciPlatformContext;
        }

        public static string GetHashValue(string text)
        {
            var hasedbytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(text));

            return BitConverter.ToString(hasedbytes).Replace("-", "").ToLower();
        }

        public UserDTO Login(UserDTO user)
        {
            UserWithRole? isUserAvailable = _ciPlatformContext.UserWithRoles.FirstOrDefault(u => u.Email == user.Email);
            if(isUserAvailable != null && !string.IsNullOrWhiteSpace(user.Password))
            {
                    string HasedPassword = GetHashValue(user.Password);
                    if (isUserAvailable.Password == HasedPassword)
                    {
                        user.Role = isUserAvailable.Role ?? 3;
                        user.UserId = isUserAvailable.UserId;
                        user.Password = string.Empty;
                        return user;
                    }
                    else return user;
            }
            else return user;
        }
    }
}
