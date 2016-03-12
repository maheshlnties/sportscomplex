using System.Data.SqlClient;

namespace SportsComplex.Database
{
    public class SqlHelper
    {
        public static bool ExecuteNonQueryCommand(string sqlQuery)
        {
            using (var cmd = new SqlCommand(sqlQuery))
            {
               return ExecuteNonQueryCommand(cmd);
            }
        }

        public static bool ExecuteNonQueryCommand(SqlCommand sqlCommand)
        {
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                sqlCommand.Connection = conn;
                var result = sqlCommand.ExecuteNonQuery();
                return result > 0 ;
            }
        }

        //public static SqlDataReader ExecuteReaderCommand(string sqlQuery)
        //{
        //    using (var conn = new SqlConnection(SqlQueries.ConnectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new SqlCommand(sqlQuery, conn))
        //        {
        //            return cmd.ExecuteReader();
        //        }
        //    }
        //}


        public static bool CheckHasRows(string sqlQuery)
        {
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sqlQuery, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
    }
}
