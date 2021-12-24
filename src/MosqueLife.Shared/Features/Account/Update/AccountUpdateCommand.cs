namespace MosqueLife.Shared.Features.Account.UpdateAccount;

public record AccountUpdateCommand
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
}