using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Framework.DataAccess.EFDataContext
{
    public interface IUnitOfWorkBase : IDisposable
    {
        DbContextReader CreatDbContextReader(AccessType reader);
        DbContextWriter CreatDbContextWriter(AccessType writer);
    }


    public interface IUnitOfWorkBaseInternal
    {
        DbContextWriter CurrentEFCtxInternal { get; set; }
        int Commit();

    }
}
