using FluentValidation;
using HRMS.Candidate.AggregateRoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.AggregateRoot
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.Phone).NotEmpty().Length(11).WithMessage("Phone number must be exactly 11 digits.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid Email is required.");
            RuleFor(x => x.Salary).GreaterThan(0).WithMessage("Salary must be a positive number."); // Adjusted for int
            RuleFor(x => x.NationalIdNumber)
                .InclusiveBetween(1000000000L, 9999999999L)
                .WithMessage("National ID Number must be exactly 10 digits.");
        }
    }
}
