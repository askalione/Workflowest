using Stateless;
using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows.Stateless
{
    interface IStateMachineConfigurator<TObject, TState, TEvent> where TObject : class
    {
        void Configure(StateMachine<TState, TEvent> stateMachine, TObject @object);
    }
}
