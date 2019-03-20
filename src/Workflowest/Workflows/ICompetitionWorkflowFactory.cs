using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows
{
    interface ICompetitionWorkflowFactory : IWorkflowFactory<ICompetitionWorkflow, Competition, Guid, ECompetitionState, ECompetitionEvent>
    {
    }
}
