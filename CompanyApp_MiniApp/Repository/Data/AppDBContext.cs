using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-077NBD3\\SQLEXPRESS;DataBase=CompanyAppMini;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
