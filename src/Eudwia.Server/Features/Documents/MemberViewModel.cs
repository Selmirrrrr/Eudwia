namespace Eudwia.Server.Features.Documents;

public class MemberViewModel
{
    public string Prenom { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public string Rue { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Ville { get; set; } = string.Empty;
    public string Npa { get; set; } = string.Empty;
    public string Pays { get; set; } = string.Empty;
    public string? Canton { get; set; } = string.Empty;

    public SubscriptionsPaidViewModel SubscriptionsPaid { get; set; } = new SubscriptionsPaidViewModel
    {
        Year = 2021,
    };
    
}