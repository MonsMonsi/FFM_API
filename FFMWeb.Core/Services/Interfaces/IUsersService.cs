using FFMWeb.Core.API.Models.Create;
using FFMWeb.Core.API.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> GetByIdentifierAsync(string identifier);
        Task<UserModel> CreateAsync(CreateUserModel model);
    }
}
