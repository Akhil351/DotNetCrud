namespace crud.Response;

public class ApiResponse
{
    public string Status { get; set; }
    public DateTime TimeStamp { get; set;}
    public object Data { get; set; }
    public object Error { get; set; }
}