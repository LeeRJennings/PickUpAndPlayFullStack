using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickUpAndPlay.Repositories;

namespace PickUpAndPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillLevelController : ControllerBase
    {
        private readonly ISkillLevelRepository _skillLevelRepo;

        public SkillLevelController(ISkillLevelRepository skillLevelRepo)
        {
            _skillLevelRepo = skillLevelRepo;
        }

        [HttpGet]
        public IActionResult GetSkillLevels()
        {
            return Ok(_skillLevelRepo.GetAllSkillLevels());
        }
    }
}
