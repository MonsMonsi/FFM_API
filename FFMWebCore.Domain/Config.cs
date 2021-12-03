using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFMWebCore.Domain
{
    public class Config
    {
        public string ConnectionString { get; set; }
        
        public static Config GetConfig()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Config.json");

            return JsonSerializer.Deserialize<Config>(File.ReadAllText(path));
        }
    }
}
