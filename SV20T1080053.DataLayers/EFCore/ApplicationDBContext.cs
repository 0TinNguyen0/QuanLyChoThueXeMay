using Microsoft.EntityFrameworkCore;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DataLayers.EFCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<MotocycleType> MotocycleTypes { get; set; }
        public DbSet<MotocycleStatus> MotocycleStatus { get; set; }
        public DbSet<MotocycleBrand> MotocycleBrands { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
