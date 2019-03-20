using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Domain
{
    enum ECompetitionEvent
    {
        SendToModeration,
        ReturnToEdit,
        Open,
        Close,

        Edit,
        Delete,
        ChangeOrganizer,
        AddIndicator,
        DeleteIndicator,
        CreateInvitation,
        DeleteInvitation,
        AddExpert,
        ToggleExpertIsActive
    }
}
