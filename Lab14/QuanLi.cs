using Lab14.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab14.Data
{
    public class Lab14Context : DbContext
    {
        public DbSet<MonHoc> MonHocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Lab14;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}