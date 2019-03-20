using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Abstractions
{
    interface IWorkflow<TObject, TState, TEvent> where TObject : IStateObject<TState>
    {
        TObject Object { get; }
        IEnumerable<TEvent> PermittedEvents { get; }
    }
}
