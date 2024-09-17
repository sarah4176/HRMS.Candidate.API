using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public long NationalIdNumber { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string? Position { get; set; }

        public int Salary { get; set; }
        public int? JobId { get; set; }
        public string? JobTitle { get; set; }
    }
}
