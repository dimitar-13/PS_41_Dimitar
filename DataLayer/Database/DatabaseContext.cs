using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<DatabaseUserLog> UserLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionExplorer = Environment.CurrentDirectory + "../../../../../database/";
            string databseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionExplorer, databseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<DatabaseUserLog>().Property(e => e.Id).ValueGeneratedOnAdd();


            var user = new DatabaseUser
            {
                Id = 1,
                Name = "Admin",
                Password = "admin123",
                Role = Welcome.Others.UserRoleEnum.ADMIN,
                FacultyNumber = "000000",
            };

            var student = new DatabaseUser
            {
                Id = 2,
                Name = "student",
                Password = "student123",
                Role = Welcome.Others.UserRoleEnum.STUDENT,
                FacultyNumber = "000000",
                Expires = DateTime.Now.AddDays(10),
            };

            var teacher = new DatabaseUser
            {
                Id = 3,
                Name = "teacher",
                Password = "teacher123",
                Role = Welcome.Others.UserRoleEnum.PROFESSOR,
                FacultyNumber = "000000",
                Expires = DateTime.Now.AddYears(2),
            };

            var userLog1 = new DatabaseUserLog
            {
                Id = 1,
                EventTime = DateTime.Now.AddDays(-1),
                LogMessage = "Added User",
            };

            var userLog2 = new DatabaseUserLog
            {
                Id = 2,
                EventTime = DateTime.Now.AddDays(-1),
                LogMessage = "Removed User",
            };
            var userLog3 = new DatabaseUserLog
            {
                Id = 3,
                EventTime = DateTime.Now.AddDays(-3),
                LogMessage = "Added User",
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user, student, teacher);

            modelBuilder.Entity<DatabaseUserLog>().HasData(userLog1, userLog2, userLog3);

        }
    }
}
