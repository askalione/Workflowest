using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Workflows.Abstractions;

namespace Workflowest.Domain
{
    class Competition
    {
        public Guid Id { get; private set; }
        public ECompetitionState State { get; private set; }
        public string Title { get; private set; }
        public string ReasonToFix { get; private set; }
        public int CreatorUserId { get; private set; }

        public Competition(Guid id, 
            string title, 
            int creatorUserId)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            Id = id;
            Title = title;
            CreatorUserId = creatorUserId;
            State = ECompetitionState.OnEdit;
        }

        public void ChangeState(ECompetitionState newState)
        {
            State = newState;
        }

        public void SetReasontToFix(string reasonToFix)
        {
            if (string.IsNullOrEmpty(reasonToFix))
                throw new ArgumentNullException(nameof(reasonToFix));

            ReasonToFix = reasonToFix;
        }
    }
}
