﻿using Stateless;
using System;
using System.Collections.Generic;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows.Stateless
{
    class StatelessWorkflow<TObject, TState, TEvent> : IWorkflow<TObject, TState, TEvent> where TObject : IStateObject<TState>
    {
        private readonly IStateMachineConfigurator<TObject, TState, TEvent> _stateMachineConfigurator;

        public TObject Object { get; }

        protected StatelessWorkflow(TObject @object,
            IStateMachineConfigurator<TObject, TState, TEvent> stateMachineConfigurator)
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));
            if (stateMachineConfigurator == null)
                throw new ArgumentNullException(nameof(stateMachineConfigurator));
            
            _stateMachineConfigurator = stateMachineConfigurator;
            Object = @object;
        }

        protected void Fire(TEvent @event, string failureMessage)
        {
            var stateMachine = GetStateMachine();
            if (!stateMachine.CanFire(@event))
            {
                if (string.IsNullOrEmpty(failureMessage))
                    failureMessage = $"Unable to fire event {@event.ToString()}.";
                throw new InvalidOperationException(failureMessage);
            }
            stateMachine.Fire(@event);
        }

        public IEnumerable<TEvent> GetPermittedEvents()
        {
            var stateMachine = GetStateMachine();
            return stateMachine.PermittedTriggers;
        }

        private StateMachine<TState, TEvent> GetStateMachine()
        {
            var stateMachine = new StateMachine<TState, TEvent>(() => Object.State, x => Object.ChangeState(x));
            _stateMachineConfigurator.Configure(stateMachine, Object);
            return stateMachine;
        }
    }
}
