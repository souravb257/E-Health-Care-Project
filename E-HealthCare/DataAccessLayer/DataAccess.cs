using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace E_HealthCare.DataAccessLayer
{
    class DataAccess
    {
        protected SqlConnection connection;
        protected SqlCommand command;
        public DataAccess()
        {
            try
            {
                this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EHealthCareDB"].ConnectionString);
                this.connection.Open();
            }
            catch (Exception exp) { }
        }

        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteNonQuery();
        }

        /*~DataAccess() {
            this.connection.Close();
        }*/
    }
}
