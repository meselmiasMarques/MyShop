using System.Text.Json.Serialization;

namespace MyShop.Core.Responses;

public class Response<T> where T : class
{
    private readonly int _code;

    [JsonConstructor]
    public Response()
        => _code = 200;

    public Response(
        T? data,
        int code = 200,
        string? message = null)
    {
        Data = data;
        Message = message;
        _code = code;
    }

    public T? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess
        => _code is >= 200 and <= 299;

}