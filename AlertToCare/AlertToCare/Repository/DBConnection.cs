using Npgsql;
using static AlertToCare.Utility.DbConfig;

namespace AlertToCare.Repository
{
    public class DbConnection
    {
        public static NpgsqlConnection GetConnection()
        {
            var hostName = HostName;
            var userName = UserName;
            var dbName = DbName;
            var cs = "Host=" + hostName + ";Username=" +userName + 
                ";Database="+ dbName + ";";
            var con = new NpgsqlConnection(cs);
            con.Open();
            return con;
        }

        public static void CloseConnection(NpgsqlConnection con)
        {
            con.Close();
        }
    }
}
