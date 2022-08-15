using Microsoft.Extensions.Configuration;
using PickUpAndPlay.Models;
using PickUpAndPlay.Utils;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public class AreaRepository : BaseRepository, IAreaRepository
    {
        public AreaRepository(IConfiguration configuration) : base(configuration) { }

        public List<Area> GetAllAreas()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        FROM Area";
                    using (var reader = cmd.ExecuteReader())
                    {
                        var areas = new List<Area>();
                        while (reader.Read())
                        {
                            areas.Add(new Area()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                            });
                        }
                        return areas;
                    }
                }
            }
        }
    }
}
