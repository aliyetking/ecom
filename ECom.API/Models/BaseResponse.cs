namespace ECom.API.Models;

public class BaseResponse<T> where T : class
{
    
    public BaseResponse(T? data, string? message, string code)
    {
        Data = data;
        Message = message;
        Code = code;
    }
    
    public BaseResponse(T? data)
    {
        Data = data;
    }
    
    public T? Data { get; set; }
    public string? Message { get; set; }
    public string? Code { get; set; }
}