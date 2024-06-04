namespace ApiWithJWT.Dtos;

public class SuccessResponse<T>
{
    public bool IsSuccess { get; set; } = true;

    public string? Message { get; set; }

    public T? Data { get; set; }
}
