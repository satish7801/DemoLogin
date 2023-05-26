using DemoLogin.DTO;
using DemoLogin.Enum;
using DemoLogin.Models.Models;
using DemoLogin.Repository.Interface;
using DemoLogin.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Service.Services
{
    public class AuthService : BaseService<User>, IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository) : base(authRepository)
        {
            _authRepository = authRepository;
        }


        public UserDTO Login(UserDTO userDTO)
        {
           return _authRepository.Login(userDTO);
        }
        
    }
}
