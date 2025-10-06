using APIS_Degtiannikov.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIS_Degtiannikov.Context
{
    public class UserContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UserContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = 127.0.0.1;uid=root;database=TaskManager", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
