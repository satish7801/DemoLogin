using DemoLogin.DTO;
using DemoLogin.Identity;
using DemoLogin.Models.Models;
using DemoLogin.Repository.Interface;
using DemoLogin.Service.ServiceInterface;
using DemoLogin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoLogin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ISkillService _skillService;
        private readonly decimal PageSize = 10;

        public AdminController(ILogger<AdminController> logger, ISkillService skillService)
        {
            _logger = logger;
            _skillService = skillService;
        }

        [Authorize]
        public IActionResult Skill()
        {
            List<SkillDTO> skills = _skillService.Skills(1, (int)PageSize);
            List<SkillModel> skillModels = new();
            BasePagination<SkillModel> pagination = new();


            
            foreach(SkillDTO skill in skills)
            {
                SkillModel skillModel = new();
                skillModel.Id = skill.Id;
                skillModel.SkillName = skill.Name;
                skillModel.IsActive = skill.IsActive;
                skillModels.Add(skillModel);
            }
            decimal total = _skillService.GetCount(x => x.DeletedAt == null);
            pagination.Data = skillModels;
            pagination.TotalCount = (int)Math.Ceiling( total / PageSize);
            return View(pagination);
        }

        public PartialViewResult SkillNew(int PageNumber)
        {
            List<SkillDTO> skills = _skillService.Skills(PageNumber, (int)PageSize);
            List<SkillModel> skillModels = new();
            foreach (SkillDTO skill in skills)
            {
                SkillModel skillModel = new();
                skillModel.Id = skill.Id;
                skillModel.SkillName = skill.Name;
                skillModel.IsActive = skill.IsActive;
                skillModels.Add(skillModel);
            }
            return PartialView("_SkillTable", skillModels);
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        public void DeleteSkill(long Id)
        {
            _skillService.DeleteSkill(Id);
        }

        public void EditSkill(long Id, string SkillName, int Status)
        {
            _skillService.EditSkill(Id, SkillName, Status);
        }

        public void AddSkill(string SkillName, int Status)
        {
            _skillService.AddSkill( SkillName, Status);
        }
    }
}
