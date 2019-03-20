using Stateless;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows.Abstractions
{
    abstract class Workflow<TObject, TState, TEvent> : IWorkflow<TObject, TState, TEvent> where TObject : IStateObject<TState>
    {
        protected readonly IWorkflowConfigurator<TObject, TState, TEvent> WorkflowConfigurator;
        public TObject Object { get; }
        public IEnumerable<TEvent> PermittedEvents => GetPermittedEvents();

        protected Workflow(IWorkflowConfigurator<TObject, TState, TEvent> workflowConfigurator,
            TObject @object)
        {
            if (workflowConfigurator == null)
                throw new ArgumentNullException(nameof(workflowConfigurator));
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            WorkflowConfigurator = workflowConfigurator;
            Object = @object;
        }

        protected void Fire(TEvent @event, string failureMessage = null)
        {
            var stateMachine = CreateStateMachine();

            if (!stateMachine.CanFire(@event))
            {
                if (string.IsNullOrEmpty(failureMessage))
                    failureMessage = "Невозможно выполнить действие";
                throw new InvalidOperationException(failureMessage);
            }

            stateMachine.Fire(@event);
        }

        private IEnumerable<TEvent> GetPermittedEvents()
        {
            var stateMachine = CreateStateMachine();
            return stateMachine.PermittedTriggers;
        }

        private StateMachine<TState, TEvent> CreateStateMachine()
        {
            var stateMachine = new StateMachine<TState, TEvent>(() => Object.State, x => Object.ChangeState(x));
            WorkflowConfigurator.Configure(stateMachine, Object);
            return stateMachine;
        }
    }
}
