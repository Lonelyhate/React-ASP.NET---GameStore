using server.Models.Enums;

namespace server.Models.Responses;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; }
    
    public StatusCode StatusCodes { get; set; }
    
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    T Data { get; set; }
}