using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Service.Core.Mapping
{
    public interface IRequestMapper<TE, TRq>
       where TE : class
       where TRq : class
    {
        void MapFromRequest(TRq request, TE entity);
    }
    public interface IReplyMapper<TE, TRp>
        where TE : class
        where TRp : class
    {
        void MapToReply(TRp reply, TE entity);
    }
}
