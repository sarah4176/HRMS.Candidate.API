using HRMS.Candidate.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.AggregateRoot.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public long NationalIdNumber { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string? Position { get; set; }

        public int Salary { get; set; }
        public int? JobId { get; set; }
        public virtual Job? Job { get; set; }

        // Update properties from EmployeeDTO
        public void MapFromDTO(EmployeeDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            this.Id = dto.Id;
            this.Name = dto.Name;
            this.NationalIdNumber = dto.NationalIdNumber;
            this.Address = dto.Address;
            this.Phone = dto.Phone;
            this.Email = dto.Email;
            this.Position = dto.Position;
            this.Salary = dto.Salary;
            this.JobId = dto.JobId;
        }
        public void FromCandidate(ManageCandidate candidate)
        {
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate), "Candidate cannot be null.");
            }

            // Update Employee properties from the Candidate object
            this.Name = candidate.Name;
            this.NationalIdNumber = candidate.NationalIdNumber;
            this.Address = candidate.Address;
            this.Phone = candidate.Phone;
            this.Email = candidate.Email;
            this.Position = candidate.Job?.Title; // Map Job title to Position, if Job exists
            this.Salary = candidate.ExpectedSalary;
            this.JobId = candidate.JobId;
        }


        // Update properties from Candidate
        public void FromCandidateDTO(ManageCandidateDTO candidateDTO)
        {
            if (candidateDTO == null)
            {
                throw new ArgumentNullException(nameof(candidateDTO));
            }

            // Map properties from CandidateDTO to Employee
            this.Name = candidateDTO.Name;
            this.NationalIdNumber = candidateDTO.NationalIdNumber;
            this.Address = candidateDTO.Address;
            this.Phone = candidateDTO.Phone;
            this.Email = candidateDTO.Email;
            this.Position = candidateDTO.JobTitle;
            this.Salary = candidateDTO.ExpectedSalary;
            this.JobId = candidateDTO.JobId;
        }


        // Convert Employee to EmployeeDTO
        public void MapDTO(EmployeeDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            dto.Id = this.Id;
            dto.Name = this.Name;
            dto.NationalIdNumber = this.NationalIdNumber;
            dto.Address = this.Address;
            dto.Phone = this.Phone;
            dto.Email = this.Email;
            dto.Position = this.Position;
            dto.Salary = this.Salary;
            dto.JobId = this.JobId;
        }

    }
}
