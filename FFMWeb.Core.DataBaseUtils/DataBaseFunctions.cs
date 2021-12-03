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
        private readonly string _basePath = @"D:\VS_Projects\Web-Projects\JsonFiles";

        public void WriteToDb_Players(string league)
        {
            var path = Path.Combine(_basePath, "Players");

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

                        var fromDb = context.Players.Find(player.Id);
                            
                        if(fromDb == null)
                        {
                            Player playerToDb = new()
                            {
                                Id = player.Id,
                                FirstName = player.Firstname,
                                LastName = player.Lastname,
                                BirthDate = player.Birth.Date,
                                BirthCountry = player.Birth.Country,
                                BirthPlace = player.Birth.Place ?? "not found",
                                Nationality = player.Nationality,
                                Height = player.Height ?? "not found",
                                Weight = player.Weight ?? "not found",
                                Position = stats.Games.Position,
                                Photo =  player.Photo,
                                TeamId = stats.Team.Id
                            };
                            context.Players.Add(playerToDb);
                            context.SaveChanges();
                        } else
                        {
                            Console.WriteLine("player found");
                        }
                    }
                }
            }
        }
    }
}
