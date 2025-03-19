using EmployeesBBDD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBBDD.DAL
{
    class DALEmployee
    {
        private DbConnection conn = new DbConnection();
        public DALEmployee()
        {
        }

        // Métodos

        // Mostrar todos los employees
        public List<Employee> ObtenerEmployees()
        {
            List<Employee> employees = new List<Employee>();

            this.conn.sqlConnection.Open();

            string sql = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(sql, this.conn.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee(
                    reader.GetInt32(0),
                    reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                    reader.GetDateTime(5),
                    reader.GetInt32(6),
                    reader.GetDecimal(7),
                    reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                    reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9)
                );
                employees.Add(employee);
            }

            this.conn.sqlConnection.Close();

            return employees;
        }

        // Agregar un employee
        public void InsertarEmployee(Employee employee)
        {
            this.conn.sqlConnection.Open();
            string sql = "INSERT INTO Employees (first_name, last_name, email, phone_number, hire_date, job_id, salary, manager_id, department_id) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @HireDate, @JobId, @Salary, @ManagerId, @DepartmentId)";
            SqlCommand command = new SqlCommand(sql, this.conn.GetConnection());
            command.Parameters.AddWithValue("@FirstName", employee.firstName);
            command.Parameters.AddWithValue("@LastName", employee.lastName);
            command.Parameters.AddWithValue("@Email", employee.email);
            command.Parameters.AddWithValue("@PhoneNumber", employee.phoneNumber);
            command.Parameters.AddWithValue("@HireDate", employee.hireDate);
            command.Parameters.AddWithValue("@JobId", employee.jobId);
            command.Parameters.AddWithValue("@Salary", employee.salary);
            command.Parameters.AddWithValue("@ManagerId", employee.managerId);
            command.Parameters.AddWithValue("@DepartmentId", employee.departmentId);
            command.ExecuteNonQuery();
            this.conn.sqlConnection.Close();
        }

        public void EliminarEmployee(int employeeId)
        {
            this.conn.sqlConnection.Open();
            string sql = "DELETE FROM Employees WHERE employee_id = @EmployeeId";
            SqlCommand command = new SqlCommand(sql, this.conn.GetConnection());
            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            command.ExecuteNonQuery();
            this.conn.sqlConnection.Close();
        }
    }
}
