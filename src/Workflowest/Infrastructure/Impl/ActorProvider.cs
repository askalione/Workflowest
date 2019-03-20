using System;
using System.Collections.Generic;
using System.Text;

namespace Workflowest.Infrastructure.Impl
{
    class ActorProvider : IActorProvider
    {
        private readonly IUserPrincipalProvider _userPrincipalProvider;

        public EActor CurrentActor => GetCurrentActor();

        public ActorProvider(IUserPrincipalProvider userPrincipalProvider)
        {
            if (userPrincipalProvider == null)
                throw new ArgumentNullException(nameof(userPrincipalProvider));

            _userPrincipalProvider = userPrincipalProvider;
        }

        private EActor GetCurrentActor()
        {
            return _userPrincipalProvider.CurrentUserId >= 0 ? EActor.User : EActor.Vendor;
        }
    }
}
