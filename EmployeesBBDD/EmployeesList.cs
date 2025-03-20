using EmployeesBBDD.DAL;
using EmployeesBBDD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesBBDD
{
    public partial class EmployeesList: Form
    {
        static List<Employee> listEmployees = new List<Employee>();
        static DALEmployee dalEmployee = new DALEmployee();
        public EmployeesList()
        {
            InitializeComponent();
        }

        private void EmployeesList_Load(object sender, EventArgs e)
        {
            listEmployees = dalEmployee.ObtenerEmployees();
            lstEmployees.DataSource = listEmployees;
            cmbManager.DataSource = dalEmployee.ObtenerEmployees();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            Employee selectedEmployee = (Employee)lstEmployees.SelectedItem;
            dalEmployee.EliminarEmployee(selectedEmployee.employeeId);
            // Comprobar si se ha eliminado el empleado
            MessageBox.Show("Empleado eliminado correctamente");
            listEmployees = dalEmployee.ObtenerEmployees();
            lstEmployees.DataSource = null;
            lstEmployees.DataSource = listEmployees;
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            listEmployees.Clear();
            listEmployees = dalEmployee.ObtenerEmployees();
            lstEmployees.DataSource = null;
            lstEmployees.DataSource = listEmployees;
        }

        private void btnCrearEmployee_Click(object sender, EventArgs e)
        {
            // Recoger todos los campos
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            int jobId = 4;
            DateTime hired = dtpHireDate.Value;
            decimal salary = nudSalary.Value;
            Employee boss = cmbManager.SelectedItem as Employee;
            int managerId = boss.employeeId;
            int departmentId = 1;

            Employee newEmployee = new Employee(firstName, lastName, email, phone, hired, jobId, salary, managerId, departmentId);

            dalEmployee.InsertarEmployee(newEmployee);

            MessageBox.Show("Empleado insertado correctamente");
            btnActualizarTabla_Click(sender, e);
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee select = lstEmployees.SelectedItem as Employee;

            if (select != null)
            {
                string name = select.lastName;

                btnEditarEmployee.Text = $"Editar a {name}";
                txtFirstName.Text = select.firstName;
                txtLastName.Text = select.lastName;
                txtEmail.Text = select.email;
                txtPhone.Text = select.phoneNumber;
                dtpHireDate.Value = select.hireDate;
            }
            else
            {
                btnEditarEmployee.Text = "Seleccione un employee";
            }

        }

        private void btnEditarEmployee_Click(object sender, EventArgs e)
        {
            Employee selected = lstEmployees.SelectedItem as Employee;
            int id = selected.employeeId;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            DateTime hireDate = dtpHireDate.Value;
            int jobId = 4;
            int departmentId = 1;
            int managerId = 100;

            dalEmployee.EditarEmployee(
                id,
                firstName,
                lastName,
                email,
                phone,
                hireDate,
                jobId,
                departmentId,
                managerId
            );

            MessageBox.Show("Empleado editado.");
            btnActualizarTabla_Click(sender, e);
        }
    }
}
