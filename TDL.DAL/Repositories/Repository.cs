using Microsoft.EntityFrameworkCore;
using TDL.DAL.Entities;
using TDL.Interfaces;

namespace TDL.DAL.Repositories
{
    public class Repository(TodoContext todoContext) : IRepository<TodoEntity>
    {
        private readonly TodoContext _todoContext = todoContext;
        public async Task<TodoEntity> CreateAsync(TodoEntity entity)
        {
            var entry = _todoContext.Entry(entity);
            entry.State = EntityState.Added;
            await _todoContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TodoEntity> DeleteAsync(TodoEntity entity)
        {
            var entry = _todoContext.Entry(entity);
            entry.State = EntityState.Deleted;
            await _todoContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TodoEntity>> GetAllAsync() => await _todoContext.Todos.ToListAsync().ConfigureAwait(false);

        public async Task<TodoEntity> GetByIdAsync(int id) => await _todoContext.Todos.FirstOrDefaultAsync(e => e.Id == id).ConfigureAwait(false);

        public async Task<TodoEntity> UpdateAsync(TodoEntity entity)
        {
            var entry = _todoContext.Entry(entity);
            entry.State = EntityState.Modified;
            await _todoContext.SaveChangesAsync();
            return entity;
        }
    }
}
