namespace HRManagementApp.Models
{
    public class Register
    {
        public int Id { get; set; }
        public required string Surname { get; set; }
        public required string OtherNames { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Photo {  get; set; }
        public required int StaffAccessCode { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}