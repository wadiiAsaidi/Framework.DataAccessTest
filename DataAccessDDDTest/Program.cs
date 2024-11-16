using Framework.DataAccess.EFDataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DataAccessDDDTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var Data = new UserManagementUnitOfWork();
            //var user = new User();
            //user.Username = "SimpllllllleUser";
            //user.Password = "SimpleUser";
            //user.Email = "SimpleUser@test.com";
            //user.FirstName = "SimpleUser";
            //user.LastName = "SimpleUser";
            //user.Id = Guid.Parse("8785B5F5-4864-4C7C-935A-587E2461713F");

            //var role = new Role();
            //role.Name = "SimpleUser";
            //role.Code = 50;
            //role.Id = Guid.Parse("0D955AE7-8924-4A0D-9BD5-517033F7A259");

            //var userRole = new UserRole();
            //userRole.Id = Guid.Parse("8785B5F5-4864-4C7C-935A-587E2461713F");
            //userRole.UserId = Guid.Parse("1BD83D62-5A49-44A2-A325-66097BDB5727");
            //userRole.User = user;
            //userRole.RoleId = Guid.Parse("0D955AE7-8924-4A0D-9BD5-517033F7A259");
            //userRole.Role = role;

            //Data.UserRepsitory.Update(userRole);
            ////var esixtingUser1 = Data.UserRepsitory.GetAll();
            //Data.Commit();

            //var esixtingUser2 = Data.UserRepsitory.GetAll();

            //Console.WriteLine("Hello World!");
        }
    }

    //public class User
    //{
    //    public Guid Id { get; set; }
    //    public string Username { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //}
    //public class UserRole
    //{
    //    public Guid Id { get; set; }
    //    public User User { get; set; }
    //    public Guid UserId { get; set; }
    //    public Role Role { get; set; }
    //    public Guid RoleId { get; set; }
    //}
    //public class Role
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public int Code { get; set; }
    //}
    //public class UserRepsitory : RepositoryBase<UserRole>
    //{
    //    public UserRepsitory(IUnitOfWorkBase unitOfWorkBase) : base(unitOfWorkBase)
    //    {
    //    }
    //}
    //public class UserManagementUnitOfWork : UnitOfWorkBase
    //{
    //    public UserManagementUnitOfWork()
    //    {
    //        UserRepsitory = new UserRepsitory(this);
    //    }
    //    public UserRepsitory UserRepsitory { get; set; }

    //    public override IEfCtx OnInitialize(AccessType accessType)
    //    {
    //        var eFLifeCyle = new ManageEFLifeCycle(accessType, EFDriver.SqlServer);
    //        var eFCtx = GetDbContext(eFLifeCyle);

    //        return eFCtx;
    //    }

    //    public static IEfCtx GetDbContext(ManageEFLifeCycle eFLifeCycle)
    //    {
    //        var getConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=wadii1";
    //        var eFCtx = (IEfCtx)new ServiceDbContext(getConnectionString, eFLifeCycle);

    //        return eFCtx;
    //    }
    //}

    //public class ServiceDbContext : BbContextBase
    //{
    //    public ServiceDbContext(string connectionString, ManageEFLifeCycle eFLifeCycle) : base(connectionString, eFLifeCycle)
    //    {
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        //CreateModel(modelBuilder);
    //        base.OnModelCreating(modelBuilder);
    //    }

    //    //private void CreateModel(ModelBuilder modelBuilder)
    //    //{
    //    //    var location = typeof(AddUserMapping).Assembly.Location;

    //    //    foreach (var typeInfo in Assembly.LoadFrom(location).DefinedTypes)
    //    //    {
    //    //        AddEntityMapping(typeInfo, modelBuilder);
    //    //    }
    //    //}

    //    public DbSet<User> Users { get; set; }
    //    public DbSet<UserRole> UserRoles { get; set; }
    //    public DbSet<Role> Roles { get; set; }

    //}
}
