using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }

        public  string Title { get; set; }

        public  string Department { get; set; }
        public string? JobLocation { get; set; }

        public  string EmploymentType { get; set; }

        public  string Requirements { get; set; }
        public DateTime PostingDate { get; set; } = DateTime.Now;
        public DateTime ClosingDate { get; set; }

        public  string SalaryRange { get; set; }
    }
}
