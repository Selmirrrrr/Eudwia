namespace MosqueLife.Shared.Features.Account.Register;

public class RegisterResult
{
    public bool Successful { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
