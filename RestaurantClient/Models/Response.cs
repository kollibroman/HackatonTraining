namespace DefaultNamespace;

public class Response<T>
{
    public ResponseStatus Status { get; set; }
    public T Data { get; set; }
    public string Error { get; set; }
}