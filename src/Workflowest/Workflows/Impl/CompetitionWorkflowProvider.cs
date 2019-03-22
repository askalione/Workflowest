using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;
using Workflowest.Workflows.Stateless;

namespace Workflowest.Workflows.Impl
{
    class CompetitionWorkflowProvider : StatelessWorkflowProvider<ICompetitionWorkflow, Competition, Guid, ECompetitionState, ECompetitionEvent>, ICompetitionWorkflowProvider
    {
        // NOTE: Inject Competition repository etc

        public CompetitionWorkflowProvider(IStateMachineFactory<Competition, ECompetitionState, ECompetitionEvent> stateMachineFactory,
            IStateMachineConfigurator<Competition, ECompetitionState, ECompetitionEvent> stateMachineConfigurator)
            : base(stateMachineFactory, 
                  stateMachineConfigurator)
        {
        }

        public override ICompetitionWorkflow GetWorkflowByObjectId(Guid id)
        {
            // Get competition from repository by general specification
            var competition = new Competition(id, "Competition #" + new Random().Next(1, 100).ToString(), 1);
            return new CompetitionWorkflow(competition, 
                StateMachineFactory,
                StateMachineConfigurator);
        }
    }
}
