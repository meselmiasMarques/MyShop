namespace MyShop.Core.Responses;

public class Response<T> where T : class
{
    public Response(string error)
    {
        Errors.Add(error);
    }
    
    public Response(T data)
        =>  Data = data;

    public Response()
    {
    }

    public T Data { get; set; }
    public string Error { get; set; }
    public List<string> Errors { get; set; } = new();


}