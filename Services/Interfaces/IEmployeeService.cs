using RosterManagementSystem.DTOs.Employee;

namespace RosterManagementSystem.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllAsync();

        Task<EmployeeResponseDto?> GetByIdAsync(int id);

        Task<EmployeeResponseDto> AddAsync(CreateEmployeeDto dto);

        Task<EmployeeResponseDto?> UpdateAsync(int id, UpdateEmployeeDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
