namespace MosqueLife.Shared.Features.Account.Update;

public record AccountUpdateCommand
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}