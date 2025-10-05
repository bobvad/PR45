using APIS_Degtiannikov.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIS_Degtiannikov.Context
{
    public class TasksContext: DbContext
    {
        public DbSet<Task> Tasks { get; set; }  
        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = 127.0.0.1;uid=root;database=TaskManager",new MySqlServerVersion(new Version(8,0,11)));
        }
    }
}
