using TDL.Interfaces;

namespace TDL.BLL
{
    public class BaseResponse<T> : IResponse<T> where T : class, new()
    {
        public string Message { get; set; }
        public T Value { get; set; }
    }
}