using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows.Impl
{
    class CompetitionWorkflowFactory : ICompetitionWorkflowFactory
    {
        // NOTE: Inject Competition repository etc

        private readonly ICompetitionWorkflowConfigurator _workflowConfigurator;

        public CompetitionWorkflowFactory(ICompetitionWorkflowConfigurator workflowConfigurator)
        {
            if (workflowConfigurator == null)
                throw new ArgumentNullException(nameof(workflowConfigurator));

            _workflowConfigurator = workflowConfigurator;
        }
        
        public ICompetitionWorkflow CreateWorkflow(Guid id)
        {
            // Get competition from repository by general specification
            var competition = new Competition(id, "Competition #" + new Random().Next(1, 100).ToString(), 1);
            return new CompetitionWorkflow(_workflowConfigurator, competition);
        }
    }
}
