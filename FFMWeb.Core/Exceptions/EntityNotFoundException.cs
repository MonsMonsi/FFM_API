using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string message): base(message)
        {

        }
    }
}
