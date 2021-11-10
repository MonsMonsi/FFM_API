using AutoMapper;
using FFMWeb.Core.API.Exceptions;
using FFMWeb.Core.API.Models.Create;
using FFMWeb.Core.API.Models.Data;
using FFMWeb.Core.API.Services.Interfaces;
using FFMWebCore.Data;
using FFMWebCore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(FootballContext context, IHttpContextAccessor contextAccessor, IMapper mapper) : base(context, contextAccessor, mapper)
        {
        }

        public async Task<UserModel> CreateUserAsync(CreateUserModel model)
        {
            var user = new User
            {
                Identifier = model.Identifier,
                EMail = model.Email
            };

            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();

            return Mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
            {
                throw new EntityNotFoundException($"No user with the Id: {id}");
            }

            return Mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> GetUserByIdentifierAsync(string identifier)
        {
            var user = await Context.Users.Where(u => u.Identifier == identifier).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new EntityNotFoundException($"No user with the Identifier: {identifier}");
            }

            return Mapper.Map<UserModel>(user);
        }
    }
}
