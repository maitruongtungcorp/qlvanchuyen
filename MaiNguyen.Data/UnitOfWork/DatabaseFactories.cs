using Microsoft.Practices.EnterpriseLibrary.Data;
namespace MaiNguyen.Data.UnitOfWork
{
    public class DatabaseFactories
    {
        private const string VanChuyenConnection = "QuanLyVanChuyen";
        DatabaseFactories()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
        }
        public static Database CreateQuanLyVanChuyenDatabase()
        {
           // Database mydb = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(VanChuyenConnection);
             return DatabaseFactory.CreateDatabase(VanChuyenConnection);
           // return mydb;
        }

    }

}
