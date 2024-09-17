using FluentValidation;
using HRMS.Candidate.AggregateRoot.Models;
using HRMS.Candidate.DTOs;
using HRMS.Candidate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Candidate.Handler.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IManageCandidateRepository _manageCandidateRepository;  // Use specific repository
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IValidator<ManageCandidateDTO> _manageCandidateValidator;

        public CandidateService(IManageCandidateRepository manageCandidateRepository,  // Inject specific repository
                                IGenericRepository<Employee> employeeRepository,
                                IJobRepository jobRepository,
                                IValidator<ManageCandidateDTO> manageCandidateValidator)
        {
            _manageCandidateRepository = manageCandidateRepository;
            _employeeRepository = employeeRepository;
            _jobRepository = jobRepository;
            _manageCandidateValidator = manageCandidateValidator;
        }

        public IEnumerable<ManageCandidateDTO> GetAllCandidates(string searchTerm = null)
        {
            // Use repository method to handle complex query
            var candidates = _manageCandidateRepository.GetAllCandidates(searchTerm);
            return candidates.Select(c =>
            {
                var dto = new ManageCandidateDTO();
                c.CandidateMapToDTO(dto);  // Mapping logic in a separate file
                return dto;
            });
        }

        public ManageCandidateDTO GetCandidateById(int id)
        {
            var candidate = _manageCandidateRepository.GetCandidateByIdWithJob(id);

            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate not found.");
            }

            var dto = new ManageCandidateDTO();
            candidate.CandidateMapToDTO(dto);
            return dto;
        }

        public void AddCandidate(ManageCandidateDTO manageCandidateDTO)
        {
            if (manageCandidateDTO == null)
            {
                throw new ArgumentNullException(nameof(manageCandidateDTO), "Candidate cannot be null.");
            }

            // Validate using FluentValidation
            var validationResult = _manageCandidateValidator.Validate(manageCandidateDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var candidate = new ManageCandidate();
            candidate.MapFromCandidateDTO(manageCandidateDTO);
            _manageCandidateRepository.Add(candidate);
        }

        public void UpdateCandidate(ManageCandidateDTO manageCandidateDTO)
        {
            if (manageCandidateDTO == null)
            {
                throw new ArgumentNullException(nameof(manageCandidateDTO), "Candidate cannot be null.");
            }

            var validationResult = _manageCandidateValidator.Validate(manageCandidateDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var candidate = _manageCandidateRepository.GetById(manageCandidateDTO.Id);
            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate not found.");
            }

            candidate.MapFromCandidateDTO(manageCandidateDTO);
            _manageCandidateRepository.Update(candidate);
        }

        public void ExportToEmployee(ManageCandidateDTO manageCandidateDTO)
        {
            if (manageCandidateDTO == null)
            {
                throw new ArgumentNullException(nameof(manageCandidateDTO), "Candidate cannot be null.");
            }

            var candidate = _manageCandidateRepository.GetById(manageCandidateDTO.Id);
            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate not found.");
            }

            candidate.MapFromCandidateDTO(manageCandidateDTO);
            var employee = new Employee();
            employee.FromCandidate(candidate);
            _employeeRepository.Add(employee);
        }

        public void DeleteCandidate(int id)
        {
            var candidate = _manageCandidateRepository.GetById(id);
            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate not found.");
            }

            _manageCandidateRepository.Delete(id);
        }

        public IEnumerable<JobDTO> GetJobList()
        {
            return _jobRepository.GetJobList();
        }

        public IEnumerable<ManageCandidateDTO> SearchCandidates(string searchTerm = null)
        {
          
            var candidates = _manageCandidateRepository.SearchCandidates(searchTerm);
            return candidates.Select(c =>
            {
                var dto = new ManageCandidateDTO();
                c.CandidateMapToDTO(dto);  
                return dto;
            });
        }
    }
}
