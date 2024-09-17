using HRMS.Candidate.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.AggregateRoot.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
    
        public string Title { get; set; }
    
        public string Department { get; set; }
        public string? JobLocation { get; set; }
    
        public string EmploymentType { get; set; }
    
        public string Requirements { get; set; }
        public DateTime PostingDate { get; set; } = DateTime.Now;
        public DateTime ClosingDate { get; set; }
    
        public string SalaryRange { get; set; }

        // Navigation Property
        public virtual ICollection<ManageCandidate> Candidates { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public JobDTO MapJobDTO()
        {
            var dto = new JobDTO
            {
                Id = this.Id,
                Title = this.Title ?? string.Empty,
                SalaryRange = this.SalaryRange ?? string.Empty,
                Requirements = this.Requirements ?? string.Empty,
                EmploymentType = this.EmploymentType ?? string.Empty,
                Department = this.Department ?? string.Empty
            };

            return dto;
        }
    }
}
