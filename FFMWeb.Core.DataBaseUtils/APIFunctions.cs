using FFMWeb.Core.DataBaseUtils.ResponseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFMWeb.Core.DataBaseUtils
{
    public class APIFunctions
    {
        private readonly string _basePath = @"D:\VS_Projects\Web-Projects\JsonFiles";
        private List<int> _teamIds = new ();

        public void WriteToJson_Squads(int league, int season)
        {
            GetTeamIds(league, season);
        }

        private void GetTeamIds(int league, int season)
        {
            var path = Path.Join(_basePath, "TeamsVenues", $"TeamsVenues_L{league}S{season}.json");

            if (!File.Exists(path))
            {
                WebClient client = new();
                client.Headers.Add("x-apisports-key", "a3a80245cddcf074947be5c6ac43484f");

                var json = JsonSerializer.Deserialize<JsonTeamsVenues.Root>(client.DownloadString($"https://v3.football.api-sports.io/teams?league={league}&season={season}"));

                File.WriteAllText(path, JsonSerializer.Serialize(json));

                SetTeamIds(json);
            }
            else
            {
                var json = JsonSerializer.Deserialize<JsonTeamsVenues.Root>(File.ReadAllText(path));

                SetTeamIds(json);
            }
        }

        private void SetTeamIds(JsonTeamsVenues.Root json)
        {
            _teamIds.Clear();
            foreach (var r in json.Response)
            {
                _teamIds.Add(r.Team.Id);
            }
        }
    }
}
