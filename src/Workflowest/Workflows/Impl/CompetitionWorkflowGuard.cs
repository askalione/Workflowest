using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Infrastructure;

namespace Workflowest.Workflows.Impl
{
    class CompetitionWorkflowGuard : ICompetitionWorkflowGuard
    {
        public bool HasReasonToFix { get; }
        public bool ActorIsCreator { get; }

        public CompetitionWorkflowGuard(IUserPrincipalProvider userPrincipalProvider,
            Competition competition)
        {
            if (userPrincipalProvider == null)
                throw new ArgumentNullException(nameof(userPrincipalProvider));

            HasReasonToFix = !string.IsNullOrEmpty(competition.ReasonToFix);
            ActorIsCreator = competition.CreatorUserId == userPrincipalProvider.CurrentUserId;
        }
    }
}
