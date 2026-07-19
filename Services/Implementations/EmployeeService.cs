using RosterManagementSystem.DTOs.Employee;
using RosterManagementSystem.Models;
using RosterManagementSystem.Repositories.Interfaces;
using RosterManagementSystem.Services.Interfaces;

namespace RosterManagementSystem.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FullName = e.FullName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Gender = e.Gender,
                EmployeeLevel = e.EmployeeLevel,
                IsActive = e.IsActive
            });
        }

        public async Task<EmployeeResponseDto?> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return null;

            return new EmployeeResponseDto
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                EmployeeLevel = employee.EmployeeLevel,
                IsActive = employee.IsActive
            };
        }

        public async Task<EmployeeResponseDto> AddAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                EmployeeCode = dto.EmployeeCode,
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                EmployeeLevel = dto.EmployeeLevel,
                IsActive = true
            };

            var createdEmployee = await _employeeRepository.AddAsync(employee);

            return new EmployeeResponseDto
            {
                Id = createdEmployee.Id,
                EmployeeCode = createdEmployee.EmployeeCode,
                FullName = createdEmployee.FullName,
                Email = createdEmployee.Email,
                PhoneNumber = createdEmployee.PhoneNumber,
                Gender = createdEmployee.Gender,
                EmployeeLevel = createdEmployee.EmployeeLevel,
                IsActive = createdEmployee.IsActive
            };
        }

        public async Task<EmployeeResponseDto?> UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return null;

            employee.EmployeeCode = dto.EmployeeCode;
            employee.FullName = dto.FullName;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Gender = dto.Gender;
            employee.EmployeeLevel = dto.EmployeeLevel;
            employee.IsActive = dto.IsActive;

            var updatedEmployee = await _employeeRepository.UpdateAsync(employee);

            return new EmployeeResponseDto
            {
                Id = updatedEmployee!.Id,
                EmployeeCode = updatedEmployee.EmployeeCode,
                FullName = updatedEmployee.FullName,
                Email = updatedEmployee.Email,
                PhoneNumber = updatedEmployee.PhoneNumber,
                Gender = updatedEmployee.Gender,
                EmployeeLevel = updatedEmployee.EmployeeLevel,
                IsActive = updatedEmployee.IsActive
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _employeeRepository.DeleteAsync(id);
        }
    }
}