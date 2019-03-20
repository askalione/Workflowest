using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Abstractions
{
    interface IStateObject<TState>
    {
        TState State { get; }
        void ChangeState(TState state);
    }
}
