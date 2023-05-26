using DemoLogin.DTO;
using DemoLogin.Helper;
using DemoLogin.Repository.Interface;
using DemoLogin.Service.ServiceInterface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace DemoLogin.Service.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void AddEntity(T entity)
        {
            _repository.AddEntity(entity);
        }

        public void DeleteEntity(T entity)
        {
            _repository.DeleteEntity(entity);
        }

        public void EditEntity(T entity)
        {
            _repository.EditEntity(entity);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetCount(predicate);
        }

        public T GetEntity(long Id)
        {
            return _repository.Get(Id);
        }


        public string GenerateToken(UserDTO user, string Key, string Issuer, string Audience)
        {
            //return Helper.Helper.GenerateToken(user, Key, Issuer, Audience);
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim("userId", user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("Role", user.Role.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            if (user.Role == 2)
            {
                claims = claims.Append(new Claim("admin", "true")).ToArray();
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(4),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}