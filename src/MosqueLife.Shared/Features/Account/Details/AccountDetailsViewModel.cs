namespace MosqueLife.Shared.Features.Account.Details;

public record AccountDetailsViewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
}
