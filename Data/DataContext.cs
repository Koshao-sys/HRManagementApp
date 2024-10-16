﻿using HRManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRManagementApp.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Register> Registers { get; set; }
        public DbSet<ApiPerformanceLogs> ApiPerformanceLogs { get; set; }
    }
}
