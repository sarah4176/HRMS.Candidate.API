using HRMS.Candidate.AggregateRoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> SearchEmployees(string searchTerm);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeByIdWithValidation(int id);
    }

}
