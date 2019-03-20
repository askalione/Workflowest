using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflowest.Domain;

namespace Workflowest.Infrastructure.Impl
{
    class UserPrincipalProvider : IUserPrincipalProvider
    {
        public int CurrentUserId { get; } = 1;

        private readonly IEnumerable<EPermission> _permissions = new List<EPermission> {
            EPermission.CompetitionChangeState,
            EPermission.CompetitionModerate
        };

        public bool HasPermission(EPermission permission)
        {
            return _permissions.Contains(permission);
        }        
    }
}
