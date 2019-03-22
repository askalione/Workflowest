using Stateless;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Stateless
{
    interface IStateMachineFactory<TObject, TState, TEvent> where TObject : class
    {
        StateMachine<TState, TEvent> CreateStateMachine(TObject @object);
    }
}
