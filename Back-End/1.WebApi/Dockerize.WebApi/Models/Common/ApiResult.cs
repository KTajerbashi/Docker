using Microsoft.AspNetCore.Mvc;

namespace Dockerize.WebApi.Models.Common;

public class ApiResult<T> : ObjectResult
{
    public ApiResult(object? value) : base(value)
    {
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
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