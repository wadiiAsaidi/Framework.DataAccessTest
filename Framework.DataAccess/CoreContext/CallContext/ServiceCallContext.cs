using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DataAccess.CoreContext.CallContext
{
    public class ServiceHostCallContext
    {
        public ServiceHostCallContext(CallContextType callContextType)
        {
            CallContextType = callContextType;
        }
        private CallContextType CallContextType;
    }

    public class ClientwebCallContext : ServiceHostCallContext
    {
        public ClientwebCallContext() : base(CallContextType.ClientWebType)
        {
        }
    }

    public class AuthentificationClientwebCallContext : ServiceHostCallContext
    {
        public AuthentificationClientwebCallContext() : base(CallContextType.AuthentificationType)
        {
        }
    }


}
