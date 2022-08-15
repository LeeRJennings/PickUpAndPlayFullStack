using PickUpAndPlay.Models;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public interface IAreaRepository
    {
        List<Area> GetAllAreas();
    }
}