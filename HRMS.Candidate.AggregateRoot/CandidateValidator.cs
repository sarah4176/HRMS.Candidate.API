using FluentValidation;
using HRMS.Candidate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.AggregateRoot
{
    public class CandidateValidator : AbstractValidator<ManageCandidateDTO>
    {
        public CandidateValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(c => c.NationalIdNumber)
                .InclusiveBetween(1000000000L, 9999999999L)
                .WithMessage("National ID Number must be exactly 10 digits.");

            RuleFor(c => c.Phone)
                .Length(11).WithMessage("Phone number must be 11 digits.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(c => c.ExpectedSalary)
                .GreaterThan(0).WithMessage("Expected Salary must be a positive number.");

            RuleFor(c => c.ResumePath)
                .NotEmpty().WithMessage("Resume Path is required.");
        }
    }
}
