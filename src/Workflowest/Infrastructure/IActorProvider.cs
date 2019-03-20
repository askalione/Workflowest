using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Infrastructure
{
    interface IActorProvider
    {
        EActor CurrentActor { get; }
    }
}
