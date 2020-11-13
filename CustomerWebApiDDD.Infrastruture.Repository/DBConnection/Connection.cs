using System.Data.SqlClient;

namespace CustomerWebApiDDD.Infrastruture.Repository.DBConnection
{
    public class Connection
    {
        private static string GetConnectionString() => $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Customer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal static SqlConnection GetConnection() => new SqlConnection(GetConnectionString());
    }
}
