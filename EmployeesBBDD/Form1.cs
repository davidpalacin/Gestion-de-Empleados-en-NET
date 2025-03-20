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
                lstJobs.DataSource = dalJobs.ObtenerJobs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message);
            }
        }

        private void btnCrearJob_Click(object sender, EventArgs e)
        {
            string jobTitle = txtJobName.Text;
            int minSalary = Convert.ToInt32(txtMinSalary.Text);
            int maxSalary = Convert.ToInt32(txtMaxSalary.Text);

            // Validar datos
            bool isValid = ValidateData(jobTitle, minSalary, maxSalary);
            if (isValid)
            {
                // Crear objeto job
                Job job = new Job(jobTitle, minSalary, maxSalary);

                dalJobs.InsertarJob(job);
                MessageBox.Show("Job insertado correctamente");
            } else
            {
                MessageBox.Show("Datos no válidos");
            }
        }

        private bool ValidateData(string jobTitle, int minSalary, int maxSalary)
        {
            bool valid = true;
            // Validar
            if (jobTitle == "" || jobTitle == null || minSalary < 0  || maxSalary < 0 || maxSalary < minSalary)
            {
                valid = false;
            }
            return valid;
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            // Cargar jobs
            lstJobs.DataSource = null;
            lstJobs.DataSource = dalJobs.ObtenerJobs();
        }

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            Job selectedJob = (Job)lstJobs.SelectedItem;
            DialogResult result = MessageBox.Show($"¿Seguro que deseas eliminar '{selectedJob.JobTitle}'?",
                                      "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dalJobs.EliminarJob(selectedJob.JobId);
                MessageBox.Show("Job eliminado correctamente");

                // Recargar la lista después de eliminar
                lstJobs.DataSource = null;
                lstJobs.DataSource = dalJobs.ObtenerJobs();
            }
        }

        private void btnAbrirEmployees_Click(object sender, EventArgs e)
        {
            EmployeesList formEmployees = new EmployeesList();
            formEmployees.Show();
        }

        private void lstJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Job selected = lstJobs.SelectedItem as Job;
            if (selected != null)
            {
                string name = selected.JobTitle;
                btnEditarJob.Text = $"Editar {name}";
                txtJobName.Text = name;
                txtMinSalary.Text = Convert.ToString(selected.MinSalary);
                txtMaxSalary.Text = Convert.ToString(selected.MaxSalary);
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
            Job selected = lstJobs.SelectedItem as Job;
            int jobId = selected.JobId;

            dalJobs.EditarJob(jobId, newTitle, minSalary, maxSalary);
            lstJobs.SelectedIndex = jobId;
            MessageBox.Show("Job editado correctamente");
            btnActualizarTabla_Click(sender, e);
        }
    }
}
