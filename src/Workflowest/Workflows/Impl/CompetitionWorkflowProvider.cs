using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows.Impl
{
    class CompetitionWorkflowProvider : ICompetitionWorkflowProvider
    {
        // NOTE: Inject Competition repository etc

        private readonly ICompetitionStateMachineConfigurator _stateMachineConfigurator;

        public CompetitionWorkflowProvider(ICompetitionStateMachineConfigurator stateMachineConfigurator)
        {
            if (stateMachineConfigurator == null)
                throw new ArgumentNullException(nameof(stateMachineConfigurator));

            _stateMachineConfigurator = stateMachineConfigurator;
        }

        public ICompetitionWorkflow GetWorkflowByObjectId(Guid id)
        {
            // Get competition from repository by general specification
            var competition = new Competition(id, "Competition #" + new Random().Next(1, 100).ToString(), 1);
            return new CompetitionWorkflow(competition, _stateMachineConfigurator);
        }
    }
}
