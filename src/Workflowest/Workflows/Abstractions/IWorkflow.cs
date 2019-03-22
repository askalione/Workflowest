using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Abstractions
{
    interface IWorkflow<TObject, TState, TEvent> where TObject : class
    {
        TObject Object { get; }
        IEnumerable<TEvent> GetPermittedEvents();
    }
}
