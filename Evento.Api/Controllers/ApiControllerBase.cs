using System;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ? //Wynika z ustawień JwtHandlera new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            Guid.Parse(User.Identity.Name) :                                //Unikalnym subjectem będzie Id
            Guid.Empty;
    }
}