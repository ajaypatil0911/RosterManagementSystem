using System.ComponentModel.DataAnnotations;

namespace RosterManagementSystem.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        [Required]
        [StringLength(10)]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; }


        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string EmployeeLevel { get; set; } = string.Empty;
    }
}
