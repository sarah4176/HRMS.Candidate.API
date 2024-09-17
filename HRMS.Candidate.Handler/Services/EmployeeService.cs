using HRMS.Candidate.AggregateRoot.Models;
using HRMS.Candidate.DTOs;
using HRMS.Candidate.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Candidate.Handler.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDTO> SearchEmployees(string searchTerm = null)
        {
            var employees = _employeeRepository.SearchEmployees(searchTerm);
            return employees.Select(employee =>
            {
                var dto = new EmployeeDTO();
                employee.MapDTO(dto);
                return dto;
            });
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return employees.Select(employee =>
            {
                var dto = new EmployeeDTO();
                employee.MapDTO(dto);
                return dto;
            });
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeByIdWithValidation(id);
            var dto = new EmployeeDTO();
            employee.MapDTO(dto);
            return dto;
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _employeeRepository.GetEmployeeByIdWithValidation(employeeDTO.Id);
            employee.MapFromDTO(employeeDTO);
            _employeeRepository.Update(employee);
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee();
            employee.MapFromDTO(employeeDTO);
            _employeeRepository.Add(employee);
        }
    }
}
