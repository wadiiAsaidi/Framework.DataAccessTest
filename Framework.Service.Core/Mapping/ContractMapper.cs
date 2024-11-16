using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Service.Core.Mapping
{
    public static  class ContractMapper
    {
        public static TReply MapEntityToReply<TEntity, TReply>(TEntity entity, TReply request = null)
            where TEntity : class, new()
            where TReply : class, new()
        {
            var mapper = new Mapper();
            return mapper.MapEntityToReply<TEntity, TReply>(entity, request);
        }

        public static TEntity MapRequestToEntity<TRequest, TEntity>(TRequest request, TEntity entity = null)
            where TEntity : class, new()
            where TRequest : class, new()
        {
            var mapper = new Mapper();
            return mapper.MapRequestToEntity<TRequest, TEntity>(request, entity);
        }
        public static TEntity MapRequestSetToEntitySet<TRequest, TEntity>(TRequest request, TEntity entity = null)
            where TEntity : class, new()
            where TRequest : class, new()
        {
            var mapper = new Mapper();
            return mapper.MapRequestToEntity<TRequest, TEntity>(request, entity);
        }
    }
}
