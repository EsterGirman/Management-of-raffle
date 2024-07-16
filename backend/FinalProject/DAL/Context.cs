using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DAL
{
    public class Context:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Winner> Winners { get; set; }
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Id).UseIdentityColumn(1, 91);
            modelBuilder.Entity<Customer>().Property(c => c.Role).HasDefaultValue("customer");
            modelBuilder.Entity<Gift>().Property(g => g.Id).UseIdentityColumn(600, 1);
            modelBuilder.Entity<Donor>().Property(d => d.Id).UseIdentityColumn(1, 352);
            modelBuilder.Entity<Owner>().Property(o => o.Id).UseIdentityColumn(10, 1);
            modelBuilder.Entity<Category>().Property(c => c.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Purchase>().Property(p => p.Id).UseIdentityColumn(1, 3);
            modelBuilder.Entity<Winner>().Property(w => w.Id).UseIdentityColumn(52, 4);

            //modelBuilder.Entity<Purchase>().Property(p => p.CustomerId).ch;
            base.OnModelCreating(modelBuilder);
        }

    
    }


}
