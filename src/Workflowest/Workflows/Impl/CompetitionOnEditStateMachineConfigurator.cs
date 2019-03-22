using System;
using System.Collections.Generic;
using System.Text;
using Stateless;
using Workflowest.Domain;
using Workflowest.Infrastructure;
using Workflowest.Workflows.Stateless;

namespace Workflowest.Workflows.Impl
{
    class CompetitionOnEditStateMachineConfigurator : IStateMachineConfigurator<Competition, ECompetitionState, ECompetitionEvent>
    {
        private readonly IUserPrincipalProvider _userPrincipalProvider;
        private readonly IActorProvider _actorProvider;

        public CompetitionOnEditStateMachineConfigurator(IUserPrincipalProvider userPrincipalProvider,
            IActorProvider actorProvider)
        {
            if (userPrincipalProvider == null)
                throw new ArgumentNullException(nameof(userPrincipalProvider));
            if (actorProvider == null)
                throw new ArgumentNullException(nameof(actorProvider));

            _userPrincipalProvider = userPrincipalProvider;
            _actorProvider = actorProvider;
        }

        public void Configure(StateMachine<ECompetitionState, ECompetitionEvent> stateMachine, Competition competition)
        {
            ICompetitionWorkflowGuard competitionGuard = new CompetitionWorkflowGuard(_userPrincipalProvider,
                competition);

            stateMachine.Configure(ECompetitionState.OnEdit)
                .PermitIf(ECompetitionEvent.SendToModeration, ECompetitionState.OnModeration, () => _actorProvider.CurrentActorIs(EActor.User) && competitionGuard.ActorIsCreator);

        }
    }
}
