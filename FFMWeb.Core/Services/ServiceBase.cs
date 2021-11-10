using AutoMapper;
using FFMWebCore.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Services
{
    public abstract class ServiceBase: IDisposable
    {
        protected readonly FootballContext Context;
        protected readonly IHttpContextAccessor ContextAccessor;
        protected readonly IMapper Mapper;

        public ServiceBase(FootballContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            Context = context;
            ContextAccessor = contextAccessor;
            Mapper = mapper;
        }


        private bool _disposed = false;
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Context.Dispose();
        }
    }
}
