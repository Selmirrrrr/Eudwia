namespace Eudwia.Server.Features.Documents;

public class SubscriptionsPaidViewModel
{
    public int Year { get; set; }
    public bool Jan { get; set; }
    public bool Feb { get; set; }
    public bool Mar { get; set; }
    public bool Apr { get; set; }
    public bool May { get; set; }
    public bool Jun { get; set; }
    public bool Jul { get; set; }
    public bool Aug { get; set; }
    public bool Sep { get; set; }
    public bool Oct { get; set; }
    public bool Nov { get; set; }
    public bool Dec { get; set; }
    
    public string JanText => Jan ? "✔" : string.Empty;
    public string FebText => Feb ? "✔" : string.Empty;
    public string MarText => Mar ? "✔" : string.Empty;
    public string AprText => Apr ? "✔" : string.Empty;
    public string MayText => May ? "✔" : string.Empty;
    public string JunText => Jun ? "✔" : string.Empty;
    public string JulText => Jul ? "✔" : string.Empty;
    public string AugText => Aug ? "✔" : string.Empty;
    public string SepText => Sep ? "✔" : string.Empty;
    public string OctText => Oct ? "✔" : string.Empty;
    public string NovText => Nov ? "✔" : string.Empty;
    public string DecText => Dec ? "✔" : string.Empty;

    public int Nombre => new bool[] { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }.FalseCount();
    public int Montant => Nombre * 30;
}