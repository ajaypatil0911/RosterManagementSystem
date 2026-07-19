using System.ComponentModel.DataAnnotations;

namespace RosterManagementSystem.Models
{
    public class Employee
    {

        public int Id { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        
        public string Gender { get; set; } = string.Empty;

      
        public string EmployeeLevel { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<RosterDetail> RosterDetails { get; set; } = new List<RosterDetail>();

    }
}
