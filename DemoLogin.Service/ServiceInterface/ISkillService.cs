using DemoLogin.DTO;
using DemoLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Service.ServiceInterface
{
    public interface ISkillService : IService<Skill>
    {
        public List<SkillDTO> Skills(int PageNumber, int PageSize);

        public void EditSkill(long Id, string SkillName, int Status);

        public void DeleteSkill(long Id);

        public void AddSkill(string SkillName, int Status);
        
    }
}
