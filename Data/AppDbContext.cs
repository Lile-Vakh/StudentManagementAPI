using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models.Domain;

namespace StudentManagementAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Student> Students { get; set; }
}