using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBBDD.DAL
{
    class DALJob
    {
        public DbConnection conn = new DbConnection();

        public DALJob()
        {
        }

        // Método insertar job en bbdd
        public void InsertarJob(Job job)
        {
            this.conn.sqlConnection.Open();  // Ensure the connection is open
                string query = "INSERT INTO Jobs (job_title, min_salary, max_salary) VALUES (@JobTitle, @MinSalary, @MaxSalary)";
                SqlCommand cmd = new SqlCommand(query, conn.sqlConnection);
                cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                cmd.Parameters.AddWithValue("@MinSalary", job.MinSalary);
                cmd.Parameters.AddWithValue("@MaxSalary", job.MaxSalary);
                cmd.ExecuteNonQuery();
            this.conn.sqlConnection.Close();  // Ensure the connection is closed
        }

        // Método obtener jobs de bbdd
        public List<Job> ObtenerJobs()
        {
            List<Job> jobs = new List<Job>();

            this.conn.sqlConnection.Open();  // Ensure the connection is open
                string query = "SELECT * FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, conn.sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Job job = new Job(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDecimal(2),
                        reader.GetDecimal(3)
                    );
                    jobs.Add(job);
                }
            this.conn.sqlConnection.Close();  // Ensure the connection is closed
            return jobs;
        }

        public void EliminarJob(int jobId)
        {
            this.conn.sqlConnection.Open();  // Ensure the connection is open
                string query = "DELETE FROM Jobs WHERE job_id = @JobId";
                SqlCommand cmd = new SqlCommand(query, conn.sqlConnection);
                cmd.Parameters.AddWithValue("@JobId", jobId);
                cmd.ExecuteNonQuery();
            this.conn.sqlConnection.Close();  // Ensure the connection is closed
        }
    }

}
