using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickUpAndPlay.Models;
using PickUpAndPlay.Repositories;
using System;
using System.Security.Claims;

namespace PickUpAndPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepo;
        private readonly IUserProfileRepository _userProfileRepo;

        public GameController(IGameRepository gameRepo, IUserProfileRepository userProfileRepo)
        {
            _gameRepo = gameRepo;
            _userProfileRepo = userProfileRepo;
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

        [HttpPost]
        public IActionResult Post(Game game)
        {
            var currentUser = GetCurrentUserProfile();
            game.UserProfileId = currentUser.Id;
            game.CreatedDateTime = DateTime.Now;
            _gameRepo.AddGame(game);
            return Ok(game);
        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepo.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
