using System;
using System.Collections.Generic;
using System.Text;
using Stateless;
using Workflowest.Domain;
using Workflowest.Infrastructure;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows.Impl
{
    class CompetitionStateMachineConfigurator : ICompetitionStateMachineConfigurator
    {
        private readonly Func<ECompetitionState, ICompetitionStateMachineConfigurator> _configurators;

        public CompetitionStateMachineConfigurator(Func<ECompetitionState, ICompetitionStateMachineConfigurator> configurators)
        {
            if (configurators == null)
                throw new ArgumentNullException(nameof(configurators));

            _configurators = configurators;
        }

        public void Configure(StateMachine<ECompetitionState, ECompetitionEvent> stateMachine, Competition competition)
        {
            stateMachine.OnUnhandledTrigger((state, trigger) =>
            {
                throw new InvalidOperationException("Operation not defined");
            });

            var configurator = _configurators(competition.State);
            configurator.Configure(stateMachine, competition);
        }
    }
}
