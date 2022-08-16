using Microsoft.Extensions.Configuration;
using PickUpAndPlay.Models;
using PickUpAndPlay.Utils;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(IConfiguration configuration) : base(configuration) { }

        public List<Game> GetAllUpcomingGames()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT g.Id, g.UserProfileId, g.Title, g.ParkName, g.Address, g.Date, g.Time, g.AreaId, g.SkillLevelId, g.CreatedDateTime, 
	                                           g.CleatsRequired, g.WhiteAndDarkShirt, g.BarefootFriendly, 
                                               g.DogsAllowed, g.PlaygroundNearby, g.BathroomsNearby, 
                                               g.DrinkingWaterNearby, g.AllAges, g.EighteenPlus,

	                                           u.FirstName, u.LastName, a.Name AS AreaName, s.Name As SkillLevelName
	   
                                        FROM Game g
                                        JOIN UserProfile u on u.Id = g.UserProfileId
                                        JOIN Area a on a.Id = g.AreaId
                                        JOIN SkillLevel s on s.Id = g.SkillLevelId
                                        WHERE g.Date >= GETDATE()";
                    using (var reader = cmd.ExecuteReader())
                    {
                        var games = new List<Game>();
                        while (reader.Read())
                        {
                            games.Add(new Game()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                Title = DbUtils.GetString(reader, "Title"),
                                ParkName = DbUtils.GetString(reader, "ParkName"),
                                Address = DbUtils.GetString(reader, "Address"),
                                Date = DbUtils.GetDateTime(reader, "Date"),
                                Time = DbUtils.GetDateTime(reader, "Time"),
                                AreaId = DbUtils.GetInt(reader, "AreaId"),
                                SkillLevelId = DbUtils.GetInt(reader, "SkillLevelId"),
                                CreatedDateTime = DbUtils.GetDateTime(reader, "CreatedDateTime"),
                                CleatsRequired = reader.GetBoolean(reader.GetOrdinal("CleatsRequired")),
                                WhiteAndDarkShirt = reader.GetBoolean(reader.GetOrdinal("WhiteAndDarkShirt")),
                                BarefootFriendly = reader.GetBoolean(reader.GetOrdinal("BarefootFriendly")),
                                DogsAllowed = reader.GetBoolean(reader.GetOrdinal("DogsAllowed")),
                                PlaygroundNearby = reader.GetBoolean(reader.GetOrdinal("PlaygroundNearby")),
                                BathroomsNearby = reader.GetBoolean(reader.GetOrdinal("BathroomsNearby")),
                                DrinkingWaterNearby = reader.GetBoolean(reader.GetOrdinal("DrinkingWaterNearby")),
                                AllAges = reader.GetBoolean(reader.GetOrdinal("AllAges")),
                                EighteenPlus = reader.GetBoolean(reader.GetOrdinal("EighteenPlus")),
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName")
                                },
                                Area = new Area()
                                {
                                    Id = DbUtils.GetInt(reader, "AreaId"),
                                    Name = DbUtils.GetString(reader, "AreaName")
                                },
                                SkillLevel = new SkillLevel()
                                {
                                    Id = DbUtils.GetInt(reader, "SkillLevelId"),
                                    Name = DbUtils.GetString(reader, "SkillLevelName")
                                }
                            });
                        }
                        return games;
                    }
                }
            }
        }

        public List<Game> GetAllPreviousGames()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT g.Id, g.UserProfileId, g.Title, g.ParkName, g.Address, g.Date, g.Time, g.AreaId, g.SkillLevelId, g.CreatedDateTime, 
	                                           g.CleatsRequired, g.WhiteAndDarkShirt, g.BarefootFriendly, 
                                               g.DogsAllowed, g.PlaygroundNearby, g.BathroomsNearby, 
                                               g.DrinkingWaterNearby, g.AllAges, g.EighteenPlus,

	                                           u.FirstName, u.LastName, a.Name AS AreaName, s.Name As SkillLevelName
	   
                                        FROM Game g
                                        JOIN UserProfile u on u.Id = g.UserProfileId
                                        JOIN Area a on a.Id = g.AreaId
                                        JOIN SkillLevel s on s.Id = g.SkillLevelId
                                        WHERE g.Date < GETDATE()";
                    using (var reader = cmd.ExecuteReader())
                    {
                        var games = new List<Game>();
                        while (reader.Read())
                        {
                            games.Add(new Game()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                Title = DbUtils.GetString(reader, "Title"),
                                ParkName = DbUtils.GetString(reader, "ParkName"),
                                Address = DbUtils.GetString(reader, "Address"),
                                Date = DbUtils.GetDateTime(reader, "Date"),
                                Time = DbUtils.GetDateTime(reader, "Time"),
                                AreaId = DbUtils.GetInt(reader, "AreaId"),
                                SkillLevelId = DbUtils.GetInt(reader, "SkillLevelId"),
                                CreatedDateTime = DbUtils.GetDateTime(reader, "CreatedDateTime"),
                                CleatsRequired = reader.GetBoolean(reader.GetOrdinal("CleatsRequired")),
                                WhiteAndDarkShirt = reader.GetBoolean(reader.GetOrdinal("WhiteAndDarkShirt")),
                                BarefootFriendly = reader.GetBoolean(reader.GetOrdinal("BarefootFriendly")),
                                DogsAllowed = reader.GetBoolean(reader.GetOrdinal("DogsAllowed")),
                                PlaygroundNearby = reader.GetBoolean(reader.GetOrdinal("PlaygroundNearby")),
                                BathroomsNearby = reader.GetBoolean(reader.GetOrdinal("BathroomsNearby")),
                                DrinkingWaterNearby = reader.GetBoolean(reader.GetOrdinal("DrinkingWaterNearby")),
                                AllAges = reader.GetBoolean(reader.GetOrdinal("AllAges")),
                                EighteenPlus = reader.GetBoolean(reader.GetOrdinal("EighteenPlus")),
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName")
                                },
                                Area = new Area()
                                {
                                    Id = DbUtils.GetInt(reader, "AreaId"),
                                    Name = DbUtils.GetString(reader, "AreaName")
                                },
                                SkillLevel = new SkillLevel()
                                {
                                    Id = DbUtils.GetInt(reader, "SkillLevelId"),
                                    Name = DbUtils.GetString(reader, "SkillLevelName")
                                }
                            });
                        }
                        return games;
                    }
                }
            }
        }
    }
}
