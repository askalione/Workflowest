using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Infrastructure
{
    static class ActorProviderExtensions
    {
        public static bool CurrentActorIs(this IActorProvider provider, EActor actor)
        {
            return provider.CurrentActor == actor;
        }
    }
}
