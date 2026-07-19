using System.ComponentModel.DataAnnotations;

namespace RosterManagementSystem.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Employee Code is required.")]
        [StringLength(10)]
        public string EmployeeCode { get; set; } = string.Empty;
       
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string EmployeeLevel { get; set; } = string.Empty;

    }
}
