using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()             //Jeżeli nie podamy jawnie Id to stowrzy sie samo w momencie inicjalizacji klasy która dziedziczy po klasie bazowej Entity.
        {
            Id = Guid.NewGuid();
        }
    }
}
