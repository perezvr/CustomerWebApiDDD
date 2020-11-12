using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CustomerWebApiDDD.Infrastruture.Repository.ConnectionDB
{
    public class Connection
    {
        private static string GetConnectionString() => $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CasaDoCodigo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal static SqlConnection GetConnection() => new SqlConnection(GetConnectionString());
    }
}
