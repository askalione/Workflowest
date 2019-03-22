using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;
using Workflowest.Workflows.Stateless;

namespace Workflowest.Workflows
{
    interface ICompetitionStateMachineConfigurator : IStateMachineConfigurator<Competition, ECompetitionState, ECompetitionEvent>
    {
    }
}
