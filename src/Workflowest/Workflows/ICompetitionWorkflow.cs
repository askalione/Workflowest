using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows
{
    interface ICompetitionWorkflow : IWorkflow<Competition, ECompetitionState, ECompetitionEvent>
    {
        void SendToModeration();
        void ReturnToEdit(string reasonToFix);
        void Open();
        void Close();
    }
}
