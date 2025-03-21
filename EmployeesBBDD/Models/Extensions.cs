using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBBDD.DAL
{
    public partial class jobs
    {
        public override string ToString()
        {
            return $"{job_title} (from {min_salary} to {max_salary})";
        }
    }

    public partial class employees
    {
        public override string ToString()
        {
            return $"{first_name} {last_name} (${salary})";
        }
    }

    public partial class departments
    {
        public override string ToString()
        {
            return $"{department_name}";
        }
    }
}
