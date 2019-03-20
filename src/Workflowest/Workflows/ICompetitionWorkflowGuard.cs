using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Workflows
{
    interface ICompetitionWorkflowGuard
    {
        bool HasReasonToFix { get; }
        bool ActorIsCreator { get; }
    }
}
