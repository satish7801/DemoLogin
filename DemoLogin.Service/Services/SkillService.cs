using DemoLogin.DTO;
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
    public class SkillService : BaseService<Skill>, ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository) : base(skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public List<SkillDTO> Skills(int PageNumber, int PageSize)
        {
            List<SkillDTO> skills = new();

            List<Skill> OriginalSkill = _skillRepository.GetAll(x => x.DeletedAt == null).Skip((PageNumber - 1)* PageSize).Take(PageSize).ToList();
            for (int i = 0; i < OriginalSkill.Count; i++)
            {
                SkillDTO skillDTO = new SkillDTO();
                skillDTO.Id = OriginalSkill[i].SkillId;
                skillDTO.Name = OriginalSkill[i].SkillName ?? "";
                skillDTO.IsActive = OriginalSkill[i].Status == 1;
                skills.Add(skillDTO);
            }
            return skills;
        }

        public void EditSkill(long Id, string SkillName, int Status)
        {

            var skill = _skillRepository.Get(Id);
            skill.SkillName = SkillName;
            skill.Status = Status;
            skill.UpdatedAt = DateTime.UtcNow;
            _skillRepository.EditEntity(skill);
        }

        public void DeleteSkill(long Id)
        {
            var skill = _skillRepository.Get(Id);
            if (skill != null)
            {
                skill.DeletedAt = DateTime.UtcNow;
                _skillRepository.EditEntity(skill);
            }
        }

        public void AddSkill(string SkillName, int Status)
        {
            Skill skill = new Skill
            {
                SkillName = SkillName,
                Status = Status
            };
            _skillRepository.AddEntity(skill);
            
        }
    }
}
