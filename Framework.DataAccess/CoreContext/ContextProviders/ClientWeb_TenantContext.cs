//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Framework.DataAccess.CoreContext.ContextProviders
//{

//    public interface IClientWebCallContext : ITenantContext
//    {

//    }
//    public class ClientWebSaasTenantContextProvider : ClientWebTenantContextProvider
//    {

//        Dictionary<Guid, IClientWebCallContext> _CallContext = new Dictionary<Guid, IClientWebCallContext>();

//        public ITenantContext DeleteTenantContextByUri(Guid tenantId)
//        {
//            IClientWebCallContext tenantContext = null;
//            _CallContext.TryGetValue(tenantId, out tenantContext);
//            return tenantContext;

//        }

//        public ITenantContext GetTenantContextByTenantId(Guid tenantId)
//        {

//        }

//        public ITenantContext GetTenantContextByUri(Uri uri)
//        {

//        }
//    }
//}
