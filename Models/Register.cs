namespace HRManagementApp.Models
{
    public class Register
    {
        public int Id { get; set; }
        public required string Surname { get; set; }
        public required string OtherNames { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Photo {  get; set; }
        public required string StaffAccessCode { get; set; }
    }
}
