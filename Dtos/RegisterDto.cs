using System.ComponentModel.DataAnnotations;

namespace HRManagementApp.Dtos
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string OtherNames { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string? Photo { get; set; }
        public int StaffAccessCode { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
    }
}
