using FFMWeb.Core.DataBaseUtils.ResponseModels;
using FFMWebCore.Data;
using FFMWebCore.Data.Tests;
using FFMWebCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFMWeb.Core.DataBaseUtils
{
    public class DataBaseFunctions
    {
        private static FFMWebCore.Domain.Config Config = FFMWebCore.Domain.Config.GetConfig();
        public void WriteToDb_Players()
        {
            var path = Path.Combine(@$"{Config.JsonFiles}", "Players");

            var dirInfo = new DirectoryInfo(path);

            var fileInfo = dirInfo.GetFiles();

            foreach (var info in fileInfo)
            {
                var json = JsonSerializer.Deserialize<JsonPlayers.Root>(File.ReadAllText(info.ToString()),
                                                                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    
                using (var context = new FootballContext())
                {
                    for (var i = 0; i < json.Response.Length; i++)
                    {
                        var player = json.Response[i].Player;
                        var stats = json.Response[i].Statistics[0];

                        var leagueFromDb = context.Leagues.Find(stats.League.Id);

                        if(leagueFromDb == null)
                        {
                            League leagueToDb = new()
                            {
                                Id = stats.League.Id ?? 99009900,
                                Name = stats.League.Name,
                                Country = stats.League.Country,
                                Logo = stats.League.Logo,
                                Flag = stats.League.Flag,
                            };
                            context.Leagues.Add(leagueToDb);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("league found");
                        }

                        var teamFromDb = context.Teams.Find(stats.Team.Id);

                        if(teamFromDb == null)
                        {
                            Team teamToDb = new()
                            {
                                Id = stats.Team.Id,
                                Name = stats.Team.Name,
                                Logo = stats.Team.Logo,
                                LeagueId = stats.League.Id ?? 99009900,
                            };
                            context.Teams.Add(teamToDb);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("team found");
                        }

                        var playerFromDb = context.Players.Find(player.Id);
                            
                        if(playerFromDb == null)
                        {
                            Player playerToDb = new()
                            {
                                Id = player.Id,
                                FirstName = player.Firstname,
                                LastName = player.Lastname,
                                BirthDate = player.Birth.Date ?? "not found",
                                BirthCountry = player.Birth.Country,
                                BirthPlace = player.Birth.Place ?? "not found",
                                Nationality = player.Nationality,
                                Height = player.Height ?? "not found",
                                Weight = player.Weight ?? "not found",
                                Position = stats.Games.Position,
                                Photo =  player.Photo,
                                TeamId = stats.Team.Id,
                            };
                            context.Players.Add(playerToDb);
                            context.SaveChanges();
                        } 
                        else
                        {
                            Console.WriteLine("player found");
                        }
                    }
                }
            }
        }
    }
}
