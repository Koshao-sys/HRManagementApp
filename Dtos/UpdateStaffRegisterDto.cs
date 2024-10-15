using System.ComponentModel.DataAnnotations;

namespace HRManagementApp.Dtos
{
    public class UpdateStaffRegisterDto
    {
        [Required]
        public string DateOfBirth { get; set; } = string.Empty;

        public string? Photo { get; set; }
    }
}
