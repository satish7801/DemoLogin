using DemoLogin.Models.Data;
using DemoLogin.Models.Models;
using DemoLogin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Repository.Repository
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        private readonly CiPlatformContext _ciPlatformContext;
        public SkillRepository(CiPlatformContext ciPlatformContext) : base(ciPlatformContext)
        {
                _ciPlatformContext = ciPlatformContext;
        }


    }
}
