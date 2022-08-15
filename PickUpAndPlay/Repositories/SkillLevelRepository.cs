using Microsoft.Extensions.Configuration;
using PickUpAndPlay.Models;
using PickUpAndPlay.Utils;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public class SkillLevelRepository : BaseRepository, ISkillLevelRepository
    {
        public SkillLevelRepository(IConfiguration configuration) : base(configuration) { }

        public List<SkillLevel> GetAllSkillLevels()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        FROM SkillLevel";
                    using (var reader = cmd.ExecuteReader())
                    {
                        var skillLevels = new List<SkillLevel>();
                        while (reader.Read())
                        {
                            skillLevels.Add(new SkillLevel()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                            });
                        }
                        return skillLevels;
                    }
                }
            }
        }
    }
}
