using System.ComponentModel.DataAnnotations;

namespace HRManagementApp.Dtos
{
    public class UpdateStaffRegisterDto
    {
        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string OtherNames { get; set; } = string.Empty;

        [Required]
        public string DateOfBirth { get; set; } = string.Empty;

        public string? Photo { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Access Code must be 10 characters")]
        [MinLength(10, ErrorMessage = "Access Code must be 10 characters")]
        public int StaffAccessCode { get; set; }
    }
}
