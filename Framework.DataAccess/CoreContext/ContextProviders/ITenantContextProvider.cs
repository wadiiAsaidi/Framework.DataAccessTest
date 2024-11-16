using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DataAccess.CoreContext.ContextProviders
{
    public interface ITenantKey
    {
        string _TeanantId { get; set; }
        public ITenantContext _TenantContext { get; set; }
    }
    public interface ITenantContext
    {
        Uri Uri { get; set; }
        string SubDomain { get; set; }
        string SessionId { get; set; }
        ITenantKey TenantKey { get; set; }
    }
    public class TenantContext : ITenantKey
    {
        public TenantContext(string teanantId, ITenantContext tenantContext)
        {
            _TeanantId = teanantId;
            _TenantContext = tenantContext;
        }

        public string _TeanantId { get; set; }
        public ITenantContext _TenantContext { get; set; }
    }
    public interface ITenantContextProvider
    {
        ITenantContext DeleteTenantContextByUri(Guid tenantId);
        ITenantContext GetTenantContextByUri(Uri uri);
        ITenantContext GetTenantContextByTenantId(Guid tenantId);
    }

    public abstract class TenantContextProvider : ITenantContextProvider
    {
        public abstract ITenantContext DeleteTenantContextByUri(Guid tenantId);

        public abstract ITenantContext GetTenantContextByTenantId(Guid tenantId);

        public abstract ITenantContext GetTenantContextByUri(Uri uri);

        public abstract ITenantContext GetAllTenantContext();

    }
    public interface IClientWebTenantContextProvider : ITenantContextProvider
    {
        ITenantContext DeleteTenantContextByUri(Guid tenantId);
        ITenantContext GetTenantContextByUri(Uri uri);
        ITenantContext GetTenantContextByTenantId(Guid tenantId);
    }
    public abstract class ClientWebTenantContextProvider : IClientWebTenantContextProvider
    {
        public abstract ITenantContext DeleteTenantContextByUri(Guid tenantId);

        public abstract ITenantContext GetTenantContextByTenantId(Guid tenantId);

        public abstract ITenantContext GetTenantContextByUri(Uri uri);

    }

    
    public interface IServiceHostTenantContextProvider : ITenantContextProvider
    {
        ITenantContext DeleteTenantContextByUri(Guid tenantId);
        ITenantContext GetTenantContextByUri(Uri uri);
        ITenantContext GetTenantContextByTenantId(Guid tenantId);
    }
    public abstract class ServiceHostTenantContextProvider : IServiceHostTenantContextProvider
    {
        public abstract ITenantContext DeleteTenantContextByUri(Guid tenantId);
        public abstract ITenantContext GetTenantContextByTenantId(Guid tenantId);

        public abstract ITenantContext GetTenantContextByUri(Uri uri);
    }

    public class ServiceHostSaasTenantContextProvider
    {

    }


}
