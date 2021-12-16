using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen18.Models
{
    public class JasperGreenContext : DbContext
    {
        public JasperGreenContext(DbContextOptions<JasperGreenContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProvideService> ProvideServices { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure crews

            modelBuilder.ApplyConfiguration(new CrewConfig());

            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedEmployee());
            modelBuilder.ApplyConfiguration(new SeedCustomer());
            modelBuilder.ApplyConfiguration(new SeedProperty());
            modelBuilder.ApplyConfiguration(new SeedPayment());
            modelBuilder.ApplyConfiguration(new SeedCrew());
            modelBuilder.ApplyConfiguration(new SeedService());
            modelBuilder.ApplyConfiguration(new SeedState());
        }
    }
}




                    

           