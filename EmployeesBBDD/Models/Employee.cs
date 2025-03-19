using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBBDD.Models
{
    class Employee
    {
        public int employeeId;
        public string firstName;
        public string lastName;
        public string email;
        public string phoneNumber;
        public DateTime hireDate;
        public int jobId;
        public decimal salary;
        public int? managerId;
        public int? departmentId;

        public Employee(int employeeId, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, int jobId, decimal salary, int? managerId, int? departmentId)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.hireDate = hireDate;
            this.jobId = jobId;
            this.salary = salary;
            this.managerId = managerId;
            this.departmentId = departmentId;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} ({email})";
        }
    }
}
