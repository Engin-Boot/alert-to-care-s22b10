using AlertToCare.Utility;
using Npgsql;

namespace AlertToCare.Repository
{
    public class DbConnection
    {
        public static NpgsqlConnection GetConnection()
        {
            var hostName = DBConfig.hostName;
            var userName = DBConfig.userName;
            var dbName = DBConfig.dbName;
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
