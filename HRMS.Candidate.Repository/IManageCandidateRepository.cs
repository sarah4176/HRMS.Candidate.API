using HRMS.Candidate.AggregateRoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.Repository
{
    public interface IManageCandidateRepository : IGenericRepository<ManageCandidate>
    {
        IEnumerable<ManageCandidate> GetAllCandidates(string searchTerm = null);
        IEnumerable<ManageCandidate> SearchCandidates(string searchTerm);
        ManageCandidate GetCandidateByIdWithJob(int id);
    }

}
