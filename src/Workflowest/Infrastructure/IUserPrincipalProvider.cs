using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Infrastructure
{
    interface IUserPrincipalProvider
    {
        int CurrentUserId { get; }
        bool HasPermission(EPermission permission);
    }
}
