namespace Eudwia.Shared.Features.Countries.List;

public record CountriesListViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public override string ToString() => Name;
}