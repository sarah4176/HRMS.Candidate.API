using HRMS.Candidate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.Handler.Services
{
    public interface ICandidateService
    {
        IEnumerable<ManageCandidateDTO> GetAllCandidates(string searchTerm = null);

        ManageCandidateDTO GetCandidateById(int id);

        void AddCandidate(ManageCandidateDTO candidateDTO);

        void UpdateCandidate(ManageCandidateDTO candidateDTO);

        void ExportToEmployee(ManageCandidateDTO candidateDTO);
        void DeleteCandidate(int id);

        IEnumerable<ManageCandidateDTO> SearchCandidates(string searchTerm = null);
        IEnumerable<JobDTO> GetJobList(); // This is the new method
    }
}
