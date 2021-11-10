using FFMWebCore.Data;
using FFMWebCore.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FFMWeb.Core.API.Helpers
{
    public class HelperMethods
    {
        public static async Task OnTokenValidated(TokenValidatedContext ctx)
        {
            var userIdClaim = ctx.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return;
            }

            await using (var context = new FootballContext("Server=localhost\\sqlexpress;Database=FFM_WEB;Trusted_Connection=True;"))
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Identifier == userIdClaim.Value);
                if (user != null)
                {
                    return;
                }

                var email = ctx.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
                var model = new User
                {
                    EMail = email != null ? email.Value : "email",
                    Identifier = userIdClaim.Value
                };

                context.Users.Add(model);
                await context.SaveChangesAsync();
            }
        }
    }
}
