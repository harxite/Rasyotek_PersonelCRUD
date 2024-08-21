using Microsoft.EntityFrameworkCore;
using PersonelManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.DataAccess.Seeds
{
    public static class PersonelSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasData(
                new Personel
                {
                    Id = 1,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Gender = "Erkek",
                    University = "Boğaziçi Üniversitesi"
                },
                new Personel
                {
                    Id = 2,
                    FirstName = "Ayşe",
                    LastName = "Demir",
                    Gender = "Kadın",
                    University = "Orta Doğu Teknik Üniversitesi"
                }
            );

            modelBuilder.Entity<Debit>().HasData(
                new Debit
                {
                    Id = 1,
                    Name = "Araba",
                    PersonelId = 1
                },
                new Debit
                {
                    Id = 2,
                    Name = "Laptop",
                    PersonelId = 2
                }
            );
        }
    }
}
