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
    }
}
