using HRMS.Candidate.DTOs;
using HRMS.Candidate.AggregateRoot.Models;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Candidate.Repository
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<JobDTO> GetJobList()
        {
            return GetAll()
                .Select(job => new JobDTO
                {
                    Id = job.Id,
                    Title = job.Title ?? string.Empty,
                    SalaryRange = job.SalaryRange ?? string.Empty,
                    Requirements = job.Requirements ?? string.Empty,
                    EmploymentType = job.EmploymentType ?? string.Empty,
                    Department = job.Department ?? string.Empty
                })
                .Distinct()
                .ToList();
        }
    }
}
