using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBBDD
{
    class Job
    {
        public int JobId { get; set; }

        public string JobTitle { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public Job(string jobTitle, decimal? minSalary, decimal? maxSalary)
        {
            JobTitle = jobTitle;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }

        public Job(int jobId, string jobTitle, decimal? minSalary, decimal? maxSalary)
        {
            JobId = jobId;
            JobTitle = jobTitle;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }

        // toString 
        public override string ToString()
        {
            return JobId + ".- " + JobTitle + " (from " + MinSalary + " to " + MaxSalary + ")";
        }
    }
}
