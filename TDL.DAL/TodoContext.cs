using Microsoft.EntityFrameworkCore;
using TDL.DAL.Entities;

namespace TDL.DAL
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }

        public TodoContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            optionsBuilder.UseSqlServer($"Data source=.\\SQLEXPRESS;Database={currentDirectory}TodoDatabase;Trusted_Connection=True;Trust Server Certificate=True;");
        }
    }
}