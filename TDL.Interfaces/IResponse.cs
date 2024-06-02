namespace TDL.Interfaces
{
    public interface IResponse<T> where T : class, new()
    {
        public string Message { get; set; }
        public T Value { get; set; }
    }
}