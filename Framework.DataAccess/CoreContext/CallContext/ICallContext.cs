using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DataAccess.CoreContext.CallContext
{
    interface ICallContext
    {
    }

    public enum CallContextType
    {
        ClientWebType,
        AuthentificationType,
        ApiType,
        JobeType
    }
}
