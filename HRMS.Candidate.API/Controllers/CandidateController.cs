using HRMS.Candidate.DTOs;
using HRMS.Candidate.Handler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS.Candidate.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: api/Candidate
        [HttpGet]
        public ActionResult<IEnumerable<ManageCandidateDTO>> GetAllCandidates([FromQuery] string searchTerm)
        {
            var candidates = _candidateService.GetAllCandidates(searchTerm);
            return Ok(candidates);
        }

        // GET: api/Candidate/5
        [HttpGet("{id}")]
        public ActionResult<ManageCandidateDTO> GetCandidateById(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            return Ok(candidate);
        }

        // POST: api/Candidate
        [HttpPost]
        public ActionResult AddCandidate([FromBody] ManageCandidateDTO candidateDTO)
        {
            _candidateService.AddCandidate(candidateDTO);
            return CreatedAtAction(nameof(GetCandidateById), new { id = candidateDTO.Id }, candidateDTO);
        }

        // PUT: api/Candidate/5
        [HttpPut("{id}")]
        public ActionResult UpdateCandidate(int id, [FromBody] ManageCandidateDTO candidateDTO)
        {
            if (id != candidateDTO.Id)
            {
                return BadRequest("Candidate ID mismatch");
            }

            _candidateService.UpdateCandidate(candidateDTO);
            return NoContent();
        }

        // DELETE: api/Candidate/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCandidate(int id)
        {
            _candidateService.DeleteCandidate(id);
            return NoContent();
        }

        // GET: api/Candidate/jobs
        [HttpGet("jobs")]
        public ActionResult<IEnumerable<JobDTO>> GetJobList()
        {
            var jobs = _candidateService.GetJobList();
            return Ok(jobs);
        }

        // POST: api/Candidate/export-to-employee
        [HttpPost("export-to-employee")]
        public ActionResult ExportToEmployee([FromBody] ManageCandidateDTO candidateDTO)
        {
            _candidateService.ExportToEmployee(candidateDTO);
            return Ok(); // Return a success response
        }
    }
}