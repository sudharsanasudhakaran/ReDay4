using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace PeopleCRUD.Models
{
    public class UsersDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=APINP-ELPT13595;user id=sa;password=Qwertyyuiop@12345;database=UserDB");
        }
        public DbSet<User> users { get; set; }
    }
}
