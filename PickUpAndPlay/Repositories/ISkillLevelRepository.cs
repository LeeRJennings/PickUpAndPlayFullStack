using PickUpAndPlay.Models;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public interface ISkillLevelRepository
    {
        List<SkillLevel> GetAllSkillLevels();
    }
}