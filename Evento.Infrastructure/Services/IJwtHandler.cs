using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userid, string role);       //zamiast Id, email
    }
}
