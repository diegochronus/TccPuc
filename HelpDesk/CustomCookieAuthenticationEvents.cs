using HelpDesk.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HelpDesk
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly HelpDeskContext helpDeskContext;
        public CustomCookieAuthenticationEvents(HelpDeskContext helpDeskContext)
        {
            this.helpDeskContext = helpDeskContext;
        }
        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;

            // Look for the LastChanged claim.
            var sid = (from c in userPrincipal.Claims
                       where c.Type == ClaimTypes.Sid
                       select c.Value).FirstOrDefault();

            int id = string.IsNullOrEmpty(sid) ? Convert.ToInt32(-1) : Convert.ToInt32(sid);
            var usuario = helpDeskContext.Usuarios.Where(x => x.UsuarioId == id).FirstOrDefault();

            if (usuario == null)
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
