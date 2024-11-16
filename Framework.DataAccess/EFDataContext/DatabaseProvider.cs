
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
namespace Framework.DataAccess.EFDataContext
{
    public enum EFDriver
    {
        SqlServer,
        PostgreSQL,
        Sqlite,
        MySQL
    }
    public enum AccessType
    {
        SimpleReade = 1,
        SimpleWrite = 2,
        Transaction = 3
    }

    public class ManageEFLifeCycle
    {
        public ManageEFLifeCycle(AccessType accessType, EFDriver eFDriver)
        {
            _AccessType = GetAccessType(accessType);
            _EFDriver = eFDriver;
        }

        public ApplicationIntent ApplicationIntent => _AccessType;
        private ApplicationIntent _AccessType { get; set; }
        public EFDriver EFDriver => _EFDriver;
        private EFDriver _EFDriver { get; set; }

        private ApplicationIntent GetAccessType(AccessType accessType)
        {
            var applicationIntent = ApplicationIntent.ReadOnly;

            switch (accessType)
            {
                case AccessType.SimpleReade:
                    applicationIntent = ApplicationIntent.ReadOnly;
                    break;
                case AccessType.SimpleWrite:
                    applicationIntent = ApplicationIntent.ReadWrite;
                    break;
                default:
                    break;
            }

            return applicationIntent;
        }


    }
    public class DatabaseProvider
    {
        static DatabaseProvider _Instance;

        static object LockObj = new object();

        public static DatabaseProvider Instance
        {
            get
            {
                lock (LockObj)
                {
                    if (_Instance == null)
                    {
                        _Instance = new DatabaseProvider();
                    }
                }

                return _Instance;
            }
        }

        public DbContextOptions<DbContext> AlterConnectionString(ManageEFLifeCycle eFLifeCycle, string connectionString)
        {
            var contextOptions = GetDbDriver(eFLifeCycle.EFDriver, AlterConnectionString(connectionString, eFLifeCycle.ApplicationIntent));

            return contextOptions;
        }

        private static string AlterConnectionString(string connectionString, ApplicationIntent accessType)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            builder.ApplicationIntent = accessType;
            return connectionString;
        }
        private static DbContextOptions<DbContext> GetDbDriver(EFDriver driverType, string connectionString)
        {
            var contextOptions = new DbContextOptions<DbContext>();

            switch (driverType)
            {
                case EFDriver.SqlServer:
                    contextOptions = new DbContextOptionsBuilder<DbContext>()
                                   .UseSqlServer(connectionString)
                                   .Options;
                    break;

                case EFDriver.PostgreSQL:
                    contextOptions = new DbContextOptionsBuilder<DbContext>()
                                   .UseNpgsql(connectionString)
                                   .Options;
                    break;

                case EFDriver.MySQL:
                    contextOptions = new DbContextOptionsBuilder<DbContext>()
                                   .UseMySql(connectionString)
                                   .Options;
                    break;

                default:
                    break;
            }

            return contextOptions;

        }


    }
}
