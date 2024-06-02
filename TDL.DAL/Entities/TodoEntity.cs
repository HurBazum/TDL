using TDL.Interfaces;

namespace TDL.DAL.Entities
{
    public class TodoEntity : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;
    }
}