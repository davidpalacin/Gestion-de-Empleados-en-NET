using EmployeesBBDD.DAL;
using EmployeesBBDD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesBBDD
{
    public partial class EmployeesList: Form
    {
        static DALEmployee dalEmployee = new DALEmployee();
        static DALJob dalJobs = new DALJob();
        public EmployeesList()
        {
            InitializeComponent();
        }

        private void EmployeesList_Load(object sender, EventArgs e)
        {
            lstEmployees.DataSource = dalEmployee.ObtenerEmployeesLinq();
            cmbManager.DataSource = dalEmployee.ObtenerEmployeesLinq();
            cmbJob.DataSource = dalJobs.ObtenerJobsLinq();

            // Agregar la lista de departamentos
            DataClasses1DataContext dc = new DataClasses1DataContext();
            cmbDepartment.DataSource = dc.departments;
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            employees selectedEmployee = (employees)lstEmployees.SelectedItem;
            dalEmployee.EliminarEmployeeLinq(selectedEmployee.employee_id);
            MessageBox.Show("Empleado eliminado correctamente");

            btnActualizarTabla_Click(sender, e);
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            lstEmployees.DataSource = null;
            lstEmployees.DataSource = dalEmployee.ObtenerEmployeesLinq();
        }

        private void btnCrearEmployee_Click(object sender, EventArgs e)
        {
            // Recoger todos los campos
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            jobs jobs = cmbJob.SelectedItem as jobs;
            DateTime hired = dtpHireDate.Value;
            decimal salary = nudSalary.Value;
            employees manager = cmbManager.SelectedItem as employees;
            departments department = cmbDepartment.SelectedItem as departments;

            employees newEmployee = new employees
            {
                first_name = firstName,
                last_name = lastName,
                email = email,
                phone_number = phone,
                job_id = jobs.job_id,
                hire_date = hired,
                salary = salary,
                manager_id = manager.employee_id,
                department_id = department.department_id
            };

            dalEmployee.InsertarEmployeeLinq(newEmployee);

            MessageBox.Show("Empleado insertado correctamente");
            btnActualizarTabla_Click(sender, e);
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            employees select = lstEmployees.SelectedItem as employees;

            if (select != null)
            {
                string name = select.last_name;

                btnEditarEmployee.Text = $"Editar a {name}";
                txtFirstName.Text = select.first_name;
                txtLastName.Text = select.last_name;
                nudSalary.Value = select.salary;
                txtEmail.Text = select.email;
                txtPhone.Text = select.phone_number;
                dtpHireDate.Value = select.hire_date;
                cmbJob.SelectedItem = select.jobs;
                cmbDepartment.SelectedItem = select.departments;
                cmbManager.SelectedItem = select.employees2;
            }
            else
            {
                btnEditarEmployee.Text = "Seleccione un employee";
            }
        }

        private void btnEditarEmployee_Click(object sender, EventArgs e)
        {
            employees selected = lstEmployees.SelectedItem as employees;
            jobs job = cmbJob.SelectedItem as jobs;
            int jobId = job.job_id;
            departments dep = cmbDepartment.SelectedItem as departments;
            int depId = dep.department_id;
            employees manager = cmbManager.SelectedItem as employees;
            int managerId = manager.employee_id;

            dalEmployee.EditarEmployeeLinq(selected.employee_id, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, dtpHireDate.Value, jobId, depId, managerId);

            MessageBox.Show("Empleado editado.");
            btnActualizarTabla_Click(sender, e);
        }
    }
}
