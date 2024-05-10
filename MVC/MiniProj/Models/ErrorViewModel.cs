namespace MiniProj.Models;

public class ErrorViewModel         //ERROR HANDLING SATHI FILE CREATED.
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
