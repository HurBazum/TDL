namespace TDL.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
    }
}