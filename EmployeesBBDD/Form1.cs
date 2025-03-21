using EmployeesBBDD.DAL;
using EmployeesBBDD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesBBDD
{
    public partial class Form1: Form
    {
        static List<Job> jobs = new List<Job>();
        static DbConnection dbConnection = new DbConnection();
        static DALJob dalJobs = new DALJob();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                lstJobs.DataSource = dalJobs.ObtenerJobsLinq();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message);
            }
        }

        private void btnCrearJob_Click(object sender, EventArgs e)
        {
            string jobTitle = txtJobName.Text;
            decimal? minSalary = null;
            decimal? maxSalary = null;
            if (decimal.TryParse(txtMinSalary.Text, out decimal minSal))
                minSalary = minSal;
            if (decimal.TryParse(txtMaxSalary.Text, out decimal maxSal))
                maxSalary = maxSal;

            // Crear objeto job
            jobs job = new jobs
            {
                job_title = jobTitle,
                max_salary = maxSalary,
                min_salary = minSalary,
            };

            dalJobs.InsertarJobLinq(job);
            MessageBox.Show("Job insertado correctamente");
            btnActualizarTabla_Click(sender, e);
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            // Cargar jobs
            lstJobs.DataSource = null;
            lstJobs.DataSource = dalJobs.ObtenerJobsLinq();
        }

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            jobs selectedJob = (jobs)lstJobs.SelectedItem;
            DialogResult result = MessageBox.Show($"¿Seguro que deseas eliminar '{selectedJob.job_title}'?",
                                      "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dalJobs.EliminarJobLinq(selectedJob.job_id);
                MessageBox.Show("Job eliminado correctamente");

                btnActualizarTabla_Click (sender, e);
            }
        }

        private void btnAbrirEmployees_Click(object sender, EventArgs e)
        {
            EmployeesList formEmployees = new EmployeesList();
            formEmployees.Show();
        }

        private void lstJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            jobs selected = lstJobs.SelectedItem as jobs;
            if (selected != null)
            {
                string name = selected.job_title;
                btnEditarJob.Text = $"Editar {name}";
                txtJobName.Text = name;
                txtMinSalary.Text = Convert.ToString(selected.min_salary);
                txtMaxSalary.Text = Convert.ToString(selected.max_salary);
            }
            else
            {
                btnEditarJob.Text = "Seleccione un job";
            }
        }

        private void btnEditarJob_Click(object sender, EventArgs e)
        {
            string newTitle = txtJobName.Text;
            decimal minSalary = Convert.ToDecimal(txtMinSalary.Text);
            decimal maxSalary = Convert.ToDecimal(txtMaxSalary.Text);
            jobs selected = lstJobs.SelectedItem as jobs;
            int jobId = selected.job_id;

            dalJobs.EditarJobLinq(jobId, newTitle, minSalary, maxSalary);
            lstJobs.SelectedIndex = 0;
            MessageBox.Show("Job editado correctamente");
            btnActualizarTabla_Click(sender, e);
        }
    }
}
