using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Data
    {
        #region Singleton

        private static volatile Data instance = null;
        private static readonly object padlock = new object();
        readonly string conString = "Data Source=DESKTOP-Q7I260E\\SQLEXPRESS;Initial Catalog=VogattiBD;Persist Security Info=True;User ID=CoraAdmin;Password=admin";
        private Data() { }

        public static Data Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new Data();
            return instance;
        }

        #endregion

        #region queryExecute
        public DataTable Query(String query)
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();
                DataTable resultado = new DataTable();
                resultado.Load(cmd.ExecuteReader());
                return resultado;
            }
        }

        public DataTable Query(String query, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();
                DataTable resultado = new DataTable();
                cmd.Parameters.AddRange(parameters);
                resultado.Load(cmd.ExecuteReader());
                return resultado;
            }
        }

        public int Execute(String query, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
