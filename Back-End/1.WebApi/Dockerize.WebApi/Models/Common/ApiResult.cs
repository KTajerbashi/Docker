namespace Dockerize.WebApi.Models.Common;

public class ApiResult<T>
{
    public ApiResult(object? value)
    {
        Data = (T)value;
    }

    public int StatusCode { get; set; } = 0;
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }

}


public static class ApiResult
{
    public static ApiResult<T> Success<T>(T data)
    {
        return new ApiResult<T>(data)
        {
            StatusCode = 200,
            Message = "✅ Operation Run Successfully.",
            Data = data
        };
    }
    public static ApiResult<T> Faild<T>(T data)
    {
        return new ApiResult<T>(data)
        {
            StatusCode = 400,
            Message = "❌ Operation Run Faild.",
            Data = data
        };
    }
}