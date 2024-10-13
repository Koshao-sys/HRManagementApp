using HRManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Register> Registers { get; set; }
    }
}
