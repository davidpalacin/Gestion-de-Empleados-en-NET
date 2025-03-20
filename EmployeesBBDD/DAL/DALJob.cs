using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void InsertarJobLinq(jobs job)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            try
            {
                dc.jobs.InsertOnSubmit(job);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al conectar " + ex);
            }
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

        public Table<jobs> ObtenerJobsLinq()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var data = dc.jobs;
            return data;
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

        public void EliminarJobLinq(int jobId)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            try
            {
                var deleteJob = dc.jobs.FirstOrDefault(x => x.job_id == jobId);
                if (deleteJob != null)
                {
                    dc.jobs.DeleteOnSubmit(deleteJob);
                    dc.SubmitChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ha ocurrido un error " + ex.Message);
            }
        }

        public void EditarJob(int jobId, string newTitle, decimal minSalary, decimal maxSalary)
        {
            this.conn.sqlConnection.Open();
            string query = "UPDATE Jobs SET job_title = @newTitle, min_salary = @minSalary, max_salary = @maxSalary WHERE job_id = @jobId";
            SqlCommand cmd = new SqlCommand(query, conn.sqlConnection);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            cmd.Parameters.AddWithValue("@newTitle", newTitle);
            cmd.Parameters.AddWithValue("@minSalary", minSalary);
            cmd.Parameters.AddWithValue("@maxSalary", maxSalary);
            cmd.ExecuteNonQuery();
            this.conn.sqlConnection.Close();
        }

        public void EditarJobLinq(int jobId, string newTitle, decimal minSalary, decimal maxSalary)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            try
            {
                // Recuperar el trabajo desde la base de datos
                var jobEdit = dc.jobs.FirstOrDefault(x => x.job_id == jobId);

                if (jobEdit != null)
                {
                    // Actualizar las propiedades del objeto
                    jobEdit.job_title = newTitle;
                    jobEdit.min_salary = minSalary;
                    jobEdit.max_salary = maxSalary;

                    // Guardar los cambios en la base de datos
                    dc.SubmitChanges();

                    MessageBox.Show("El trabajo se ha editado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró el trabajo con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

    }

}
