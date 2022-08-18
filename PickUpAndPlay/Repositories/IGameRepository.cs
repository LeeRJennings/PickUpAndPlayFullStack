using PickUpAndPlay.Models;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public interface IGameRepository
    {
        List<Game> GetAllPreviousGames();
        List<Game> GetAllUpcomingGames();
        Game GetGameById(int id);
        void AddGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int id);
    }
}