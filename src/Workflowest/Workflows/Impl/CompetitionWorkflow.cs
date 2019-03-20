using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Workflows.Impl
{
    class CompetitionWorkflow : Workflow<Competition, ECompetitionState, ECompetitionEvent>, ICompetitionWorkflow
    {
        public CompetitionWorkflow(ICompetitionWorkflowConfigurator workflowConfigurator, 
            Competition competition) : 
            base(workflowConfigurator, 
                competition)
        {
        }
        
        public void SendToModeration()
        {
            Fire(ECompetitionEvent.SendToModeration, "Unable to send competition on moderation");
        }

        public void ReturnToEdit(string reasonToFix)
        {
            Object.SetReasontToFix(reasonToFix);
            Fire(ECompetitionEvent.ReturnToEdit, "Unable to return to edit competition");
        }

        public void Open()
        {
            Fire(ECompetitionEvent.Open, "Unable to open competition");
        }

        public void Close()
        {
            Fire(ECompetitionEvent.Close, "Unable to close competition");
        }
    }
}
