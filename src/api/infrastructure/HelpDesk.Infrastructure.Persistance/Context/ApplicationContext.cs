using HelpDesk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HelpDesk.Infrastructure.Persistance.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<DemandMessage> DemandMessages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=helpdesk;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
