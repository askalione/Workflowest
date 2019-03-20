using Stateless;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Abstractions
{
    interface IWorkflowConfigurator<TObject, TState, TEvent> where TObject : IStateObject<TState>
    {
        void Configure(StateMachine<TState, TEvent> stateMachine, TObject @object);
    }
}
