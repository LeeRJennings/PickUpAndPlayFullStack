using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickUpAndPlay.Repositories;

namespace PickUpAndPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository _areaRepo;

        public AreaController(IAreaRepository areaRepo)
        {
            _areaRepo = areaRepo;
        }

        [HttpGet]
        public IActionResult GetAreas()
        {
            return Ok(_areaRepo.GetAllAreas());
        }
    }
}
