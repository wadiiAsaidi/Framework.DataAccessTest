using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Service.Core.Mapping
{

    public class Mapper
    {
        private readonly ObjectResolver objectResolver = new ObjectResolver();

        public TReply MapEntityToReply<TEntity, TReply>(TEntity entity, TReply reply)
            where TEntity : class, new()
            where TReply : class, new()
        {
            var mapper = objectResolver.Resolve<IReplyMapper<TEntity, TReply>>();
            if (reply == null)
            {
                reply = new TReply();
            }
            mapper.MapToReply(reply, entity);

            return reply;
        }

        public TEntity MapRequestToEntity<TRequest, TEntity>(TRequest request, TEntity entity)
            where TEntity : class, new()
            where TRequest : class, new()
        {
            var mapper = objectResolver.Resolve<IRequestMapper<TEntity, TRequest>>();
            if (entity == null)
            {
                entity = new TEntity();
            }
            mapper.MapFromRequest(request, entity);
            return entity;
        }
    }
}
