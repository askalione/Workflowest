using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Abstractions
{
    interface IWorkflowFactory<TWorkflow, TObject, TObjectIdentifier, TState, TEvent> 
        where TObject : IStateObject<TState>
        where TWorkflow : IWorkflow<TObject, TState, TEvent>
    {
        TWorkflow CreateWorkflow(TObjectIdentifier id);
    }
}
