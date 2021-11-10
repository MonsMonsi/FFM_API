using FFMWeb.Core.API.Models;
using FFMWeb.Core.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services
{
    public class ValuesService : IValuesService
    {
        public async Task<CalculationResponseModel> CalculateAsync(CalculationRequestModel request)
        {
            var calculation = new CalculationResponseModel
            {
                Result = request.A + request.B
            };

            return calculation;
        }
    }
}
