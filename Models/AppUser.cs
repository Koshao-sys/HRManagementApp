using Microsoft.AspNetCore.Identity;

namespace HRManagementApp.Models
{
    public class AppUser : IdentityUser
    {
        public required string Surname { get; set; }
        public required string OtherNames { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? IdPhoto { get; set; }
        public required string AccessCode { get; set; }
    }
}
