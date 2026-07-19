using Microsoft.EntityFrameworkCore;
using RosterManagementSystem.Models;

namespace RosterManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<WeekOffRule> WeekOffRules { get; set; }

        public DbSet<Roster> Rosters { get; set; }

        public DbSet<RosterDetail> RosterDetails { get; set; }
    }
}