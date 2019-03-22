using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Workflows;

namespace Workflowest.Services.Impl
{
    class Service : IService
    {
        private readonly ICompetitionWorkflowProvider _workflowProvider;

        public Service(ICompetitionWorkflowProvider workflowFactory)
        {
            if (workflowFactory == null)
                throw new ArgumentNullException(nameof(workflowFactory));

            _workflowProvider = workflowFactory;
        }

        public void Start()
        {
            // Competition id
            Guid id = Guid.NewGuid();

            // Get workflow
            var workflow = _workflowProvider.GetWorkflowByObjectId(id);

            var permittedEvents = workflow.GetPermittedEvents();

            // Lets start

            var competition = workflow.Object;

            workflow.SendToModeration();
            workflow.ReturnToEdit("Some errors");
            workflow.Open();
        }
    }
}
