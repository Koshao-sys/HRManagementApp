using System.ComponentModel.DataAnnotations;

namespace HRManagementApp.Dtos
{
    public class RegisterStaffDto
    {
        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string OtherNames { get; set; } = string.Empty;

        [Required]
        public string DateOfBirth { get; set; } = string.Empty;

        public string? Photo { get; set; }

        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "Access Code must be a 10-digit number.")]
        public int StaffAccessCode { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
    }
}
