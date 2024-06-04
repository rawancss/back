namespace ApiWithJWT.Dtos;

public class FailureResponse
{
    public bool IsSuccess { get; set; } = false;

    public string? Message { get; set; }

}
