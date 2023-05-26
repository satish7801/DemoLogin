using DemoLogin.DTO;
using DemoLogin.Enum;
using DemoLogin.Models.Models;

namespace DemoLogin.Repository.Interface
{
    public interface IAuthRepository : IRepository<User>
    {
        public UserDTO Login(UserDTO user);

    }
}
