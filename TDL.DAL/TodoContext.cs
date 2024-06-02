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
            optionsBuilder.UseSqlServer(@"Data source=.\SQLEXPRESS;Database=TodoDatabase;Trusted_Connection=True;Trust Server Certificate=True;");
        }
    }
}