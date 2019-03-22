using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows.Stateless
{
    abstract class StatelessWorkflowProvider<TWorkflow, TObject, TObjectIdentifier, TState, TEvent> : IWorkflowProvider<TWorkflow, TObject, TObjectIdentifier, TState, TEvent>
        where TWorkflow : IWorkflow<TObject, TState, TEvent>
        where TObject : class
    {
        protected readonly IStateMachineFactory<TObject, TState, TEvent> StateMachineFactory;
        protected readonly IStateMachineConfigurator<TObject, TState, TEvent> StateMachineConfigurator;

        public StatelessWorkflowProvider(IStateMachineFactory<TObject, TState, TEvent> stateMachineFactory,
            IStateMachineConfigurator<TObject, TState, TEvent> stateMachineConfigurator)
        {
            if (stateMachineFactory == null)
                throw new ArgumentNullException(nameof(stateMachineFactory));
            if (stateMachineConfigurator == null)
                throw new ArgumentNullException(nameof(stateMachineConfigurator));

            StateMachineFactory = stateMachineFactory;
            StateMachineConfigurator = stateMachineConfigurator;
        }

        public abstract TWorkflow GetWorkflowByObjectId(TObjectIdentifier id);
    }
}
