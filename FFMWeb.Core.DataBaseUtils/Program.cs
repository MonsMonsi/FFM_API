using FFMWeb.Core.DataBaseUtils.ResponseModels;
using FFMWebCore.Data;
using FFMWebCore.Data.Tests;
using FFMWebCore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFMWeb.Core.DataBaseUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            //var api = new APIFunctions("39", "2021");
            var db = new DataBaseFunctions();

            db.WriteToDb_Players();
            // Testing
            //using (var context = new FootballContext())
            //{
            //    var test = context.Players.Include(p => p.Team);

            //    foreach (var t in test)
            //    {
            //        Console.WriteLine($"Player: {t.FirstName} Team: {t.Team.Name}");
            //    }
            //};
        }
    }
}
