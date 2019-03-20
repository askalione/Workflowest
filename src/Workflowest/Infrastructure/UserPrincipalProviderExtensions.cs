using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Infrastructure
{
    static class UserPrincipalProviderExtensions
    {
        public static bool CurrentUserHasPermission(this IUserPrincipalProvider provider, EPermission permission)
        {
            // Check if userPrincipal == null 
            if (provider.CurrentUserId < 0)
                return false;

            return provider.HasPermission(permission);
        }
    }
}
