using DemoLogin.DTO;
using DemoLogin.Enum;
using DemoLogin.Models.Models;
using DemoLogin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Service.ServiceInterface
{
    public interface IAuthService : IService<User>
    {
        public UserDTO Login(UserDTO userDTO);

    }
}
