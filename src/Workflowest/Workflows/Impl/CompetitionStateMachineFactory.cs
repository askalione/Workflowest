using System;
using System.Collections.Generic;
using System.Text;
using Stateless;
using Workflowest.Domain;
using Workflowest.Workflows.Stateless;

namespace Workflowest.Workflows.Impl
{
    class CompetitionStateMachineFactory : IStateMachineFactory<Competition, ECompetitionState, ECompetitionEvent>
    {
        public StateMachine<ECompetitionState, ECompetitionEvent> CreateStateMachine(Competition @object)
        {
            return new StateMachine<ECompetitionState, ECompetitionEvent>(() => @object.State, state => @object.ChangeState(state));
        }
    }
}
