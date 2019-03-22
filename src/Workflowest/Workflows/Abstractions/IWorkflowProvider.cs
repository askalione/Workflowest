using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Abstractions
{
    interface IWorkflowProvider<TWorkflow, TObject, TObjectIdentifier, TState, TEvent>
        where TObject : class
        where TWorkflow : IWorkflow<TObject, TState, TEvent>
    {
        TWorkflow GetWorkflowByObjectId(TObjectIdentifier id);
    }
}
