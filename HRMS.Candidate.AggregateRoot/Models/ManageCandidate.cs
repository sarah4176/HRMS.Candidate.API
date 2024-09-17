using HRMS.Candidate.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Candidate.AggregateRoot.Models
{
    public class ManageCandidate
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public long NationalIdNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string? LinkedinProfile { get; set; }
        public int ExpectedSalary { get; set; }
        public string? Status { get; set; }
        public string? ResumePath { get; set; }
        public string? Source { get; set; }

        // Foreign Key
        public int? JobId { get; set; }
        public virtual Job? Job { get; set; }

        // Update Candidate from DTO
        public void MapFromCandidateDTO(ManageCandidateDTO dto)
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
            this.ApplicationDate = dto.ApplicationDate;
            this.LinkedinProfile = dto.LinkedinProfile;
            this.ExpectedSalary = dto.ExpectedSalary;
            this.Status = dto.Status;
            this.ResumePath = dto.ResumePath;
            this.Source = dto.Source;
            this.JobId = dto.JobId;
        }

        // Convert Candidate to DTO
        public void CandidateMapToDTO(ManageCandidateDTO dto)
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
            dto.ApplicationDate = this.ApplicationDate;
            dto.LinkedinProfile = this.LinkedinProfile;
            dto.ExpectedSalary = this.ExpectedSalary;
            dto.Status = this.Status;
            dto.ResumePath = this.ResumePath;
            dto.Source = this.Source;
            dto.JobId = this.JobId;
            dto.JobTitle = this.Job?.Title; // Job title mapping
        }
    }
}
