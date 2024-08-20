using Microsoft.EntityFrameworkCore;
using PersonelManagement.Core.Entities;
using PersonelManagement.DataAccess.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelManagement.DataAccess.Seeds;

namespace PersonelManagement.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Personel> Personels { get; set; }
        public DbSet<Debit> Debits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonelConfiguration());
            PersonelSeed.Seed(modelBuilder);
        }
    }
}
