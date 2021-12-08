using FFMWeb.Core.DataBaseUtils.ResponseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FFMWeb.Core.DataBaseUtils
{
    public class APIFunctions
    {
        const int API_REQUEST_LIMIT = 10;
        const string BASE_PATH = @"D:\VS_Projects\Web-Projects\JsonFiles";
        const string BASE_URL = "https://v3.football.api-sports.io/";
        
        private static FFMWebCore.Domain.Config Config = FFMWebCore.Domain.Config.GetConfig();
        private List<int> _teamIds = new ();

        public APIFunctions(string league, string season)
        {
            _teamIds = GetTeamIds(league, season);
        }

        public APIFunctions()
        {

        }

        public void WriteToJson_Players(string league, string season)
        {
            foreach (var id in _teamIds)
            {
                var page = 1;
                var maxPage = 2;
                
                // if !File.Exists 
                while (page <= maxPage)
                {
                    WebClient client = new();
                    client.Headers.Add(Config.APIHeader, Config.APIKey);

                    var json = JsonSerializer.Deserialize<JsonPlayers.Root>(client.DownloadString($"{BASE_URL}players?league={league}&team={id}&season={season}&page={page}"),
                                                                                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    maxPage = json.Paging.Total;

                    var path = Path.Combine(BASE_PATH, "Players", $"Players_L{league}S{season}T{id}P{page}.json");

                    File.WriteAllText(path, JsonSerializer.Serialize(json));
                    
                    page++;
                    Thread.Sleep(60000 / API_REQUEST_LIMIT); // API Request-Limit (Requests per minute)
                }
                Console.WriteLine($"Team: {id} is done!");
            }
        }

        public List<int> GetTeamIds(string league, string season)
        {
            var ids = new List<int>();
            var json = new JsonTeamsVenues.Root();
            var path = Path.Join(BASE_PATH, "TeamsVenues", $"TeamsVenues_L{league}S{season}.json");

            if (!File.Exists(path))
            {
                WebClient client = new();
                client.Headers.Add(Config.APIHeader, Config.APIKey);

                json = JsonSerializer.Deserialize<JsonTeamsVenues.Root>(client.DownloadString($"{BASE_URL}teams?league={league}&season={season}"),
                                                                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                File.WriteAllText(path, JsonSerializer.Serialize(json));
            }
            else
            {
                json = JsonSerializer.Deserialize<JsonTeamsVenues.Root>(File.ReadAllText(path), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            foreach (var r in json.Response)
            {
                ids.Add(r.Team.Id);
            }

            return ids;
        }
    }
}
