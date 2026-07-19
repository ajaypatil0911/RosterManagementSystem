using Microsoft.EntityFrameworkCore;
using RosterManagementSystem.Data;
using RosterManagementSystem.Models;
using RosterManagementSystem.Repositories.Interfaces;

namespace RosterManagementSystem.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);

            if (existingEmployee == null)
                return null;

            existingEmployee.EmployeeCode = employee.EmployeeCode;
            existingEmployee.FullName = employee.FullName;
            existingEmployee.Email = employee.Email;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.IsActive = employee.IsActive;

            await _context.SaveChangesAsync();

            return existingEmployee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}