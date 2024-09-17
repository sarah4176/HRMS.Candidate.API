using HRMS.Candidate.DTOs;
using HRMS.Candidate.Handler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Candidate.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // GET: api/Employee/Search?searchTerm=value
        [HttpGet("search")]
        public ActionResult<IEnumerable<EmployeeDTO>> SearchEmployee([FromQuery] string searchTerm)
        {
            var employees = _employeeService.SearchEmployees(searchTerm);
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
