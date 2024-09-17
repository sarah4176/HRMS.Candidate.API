using FluentValidation;
using FluentValidation.Results;
using HRMS.Candidate.AggregateRoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Candidate.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly IValidator<Employee> _employeeValidator;

        public EmployeeRepository(ApplicationDbContext context, IValidator<Employee> employeeValidator)
            : base(context)
        {
            _employeeValidator = employeeValidator;
        }

        public IEnumerable<Employee> SearchEmployees(string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? GetAll()
                : Find(e => e.Name.Contains(searchTerm) ||
                            e.Email.Contains(searchTerm) ||
                            e.Position.Contains(searchTerm));
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return GetAll();
        }

        public Employee GetEmployeeByIdWithValidation(int id)
        {
            var employee = GetById(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            ValidateEmployee(employee);
            return employee;
        }

        private void ValidateEmployee(Employee employee)
        {
            ValidationResult result = _employeeValidator.Validate(employee);
            if (!result.IsValid)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}
