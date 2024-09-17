using HRMS.Candidate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.Handler.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        //void AddEmployee(EmployeeDTO employeeDTO);
        //void UpdateEmployee(EmployeeDTO employeeDTO);
        //void DeleteEmployee(int id);
        IEnumerable<EmployeeDTO> SearchEmployees(string searchTerm = null);
        // IEnumerable<EmployeeDTO> GetAllJobs();
    }
}
