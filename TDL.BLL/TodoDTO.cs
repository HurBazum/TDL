using TDL.Interfaces;

namespace TDL.BLL
{
    public class TodoDTO : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}