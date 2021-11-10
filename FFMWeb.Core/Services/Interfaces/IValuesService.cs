using FFMWeb.Core.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services.Interfaces
{
    public interface IValuesService
    {
        Task<CalculationResponseModel> CalculateAsync(CalculationRequestModel request);
    }
}
