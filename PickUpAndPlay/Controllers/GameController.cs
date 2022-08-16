using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickUpAndPlay.Repositories;

namespace PickUpAndPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepo;

        public GameController(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        [HttpGet("Upcoming")]
        public IActionResult GetAllUpcoming()
        {
            return Ok(_gameRepo.GetAllUpcomingGames());
        }

        [HttpGet("Previous")]
        public IActionResult GetAllPrevious()
        {
            return Ok(_gameRepo.GetAllPreviousGames());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _gameRepo.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }
    }

}
