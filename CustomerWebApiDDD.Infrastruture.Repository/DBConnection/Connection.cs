using System.Data.SqlClient;

namespace CustomerWebApiDDD.Infrastruture.Repository.DBConnection
{
    public class Connection
    {
        private const string DBServer = "MSSQLLocalDB";
        private const string DBCatalog = "Customer";
        private static string GetConnectionString() => $"Data Source=(localdb)\\{DBServer};Initial Catalog={DBCatalog};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal static SqlConnection GetConnection() => new SqlConnection(GetConnectionString());
    }
}
