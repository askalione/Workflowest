using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows
{
    interface ICompetitionWorkflowProvider : IWorkflowProvider<ICompetitionWorkflow, Competition, Guid, ECompetitionState, ECompetitionEvent>
    {
    }
}
