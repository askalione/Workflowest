using System;
using System.Collections.Generic;
using System.Text;
using Stateless;
using Workflowest.Domain;
using Workflowest.Infrastructure;

namespace Workflowest.Workflows.Impl
{
    class CompetitionWorkflowOpenedStateConfigurator : ICompetitionWorkflowConfigurator
    {
        private readonly IActorProvider _actorProvider;

        public CompetitionWorkflowOpenedStateConfigurator(IActorProvider actorProvider)
        {
            if (actorProvider == null)
                throw new ArgumentNullException(nameof(actorProvider));

            _actorProvider = actorProvider;
        }

        public void Configure(StateMachine<ECompetitionState, ECompetitionEvent> stateMachine, Competition @object)
        {
            stateMachine.Configure(ECompetitionState.Opened)
                .PermitIf(ECompetitionEvent.Close, ECompetitionState.Closed, () => _actorProvider.CurrentActorIs(EActor.User));
        }
    }
}
