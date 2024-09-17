using HRMS.Candidate.AggregateRoot.Models;
using HRMS.Candidate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.Repository
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        IEnumerable<JobDTO> GetJobList();
    }
}
