using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Workflows;

namespace Workflowest.Services.Impl
{
    class Service : IService
    {
        private readonly ICompetitionWorkflowFactory _workflowFactory;

        public Service(ICompetitionWorkflowFactory workflowFactory)
        {
            if (workflowFactory == null)
                throw new ArgumentNullException(nameof(workflowFactory));

            _workflowFactory = workflowFactory;
        }

        public void Start()
        {
            // Competition id
            Guid id = Guid.NewGuid();

            // Get workflow
            var workflow = _workflowFactory.CreateWorkflow(id);

            var permittedEvents = workflow.PermittedEvents;

            // Lets start

            var competition = workflow.Object;

            workflow.SendToModeration();
            workflow.ReturnToEdit("Some errors");
            workflow.Open();
        }
    }
}
