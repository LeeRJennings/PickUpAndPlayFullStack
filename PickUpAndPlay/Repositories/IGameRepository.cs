﻿using PickUpAndPlay.Models;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public interface IGameRepository
    {
        List<Game> GetAllPreviousGames();
        List<Game> GetAllUpcomingGames();
    }
}