using AutoMapper;
using FFMWeb.Core.API.Models.Data;
using FFMWebCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Config
{
    public static class AutoMapperConfig
    {
        public static IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<Season, SeasonModel>();
                cfg.CreateMap<UserTeam, UserTeamModel>();
            });

            return config.CreateMapper();
        }
        
    }
}
