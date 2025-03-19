using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBBDD
{
    class DbConnection
    {
        public string connectionString = "Data Source=46.183.117.154,54321;Database=DavidPalacinEmployees;Integrated Security=false;User ID=sa;Password=Sql#123456789;";
        public SqlConnection sqlConnection;

        public DbConnection()
        {
            sqlConnection = new SqlConnection(this.connectionString);
        }

        public void Open()
        {
            try
            {
                this.sqlConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
        }
        public void Close()
        {
            try
            {
                this.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }

        }

        public SqlConnection GetConnection()
        {
            return this.sqlConnection;
        }
    }
}
