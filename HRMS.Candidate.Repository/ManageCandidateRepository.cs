using HRMS.Candidate.AggregateRoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.Repository
{
    public class ManageCandidateRepository : GenericRepository<ManageCandidate>, IManageCandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public ManageCandidateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ManageCandidate> GetAllCandidates(string searchTerm = null)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? GetAllIncluding(c => c.Job)
                : FindIncluding(
                    c => c.Name.Contains(searchTerm) ||
                         c.Email.Contains(searchTerm) ||
                         (c.Job != null && c.Job.Title.Contains(searchTerm)),
                    c => c.Job);
        }

        public IEnumerable<ManageCandidate> SearchCandidates(string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? GetAll()
                : Find(c =>
                    c.Name.Contains(searchTerm) ||
                    c.Email.Contains(searchTerm) ||
                    (c.Job != null && c.Job.Title.Contains(searchTerm)));
        }
        public ManageCandidate GetCandidateByIdWithJob(int id)
        {
            return FindIncluding(c => c.Id == id, c => c.Job).FirstOrDefault();
        }
    }

}
