using Microsoft.AspNetCore.Components;

namespace MosqueLife.Client.Pages.Account.Login;

public partial class RedirectToLogin : ComponentBase 
{

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {
        NavigationManager.NavigateTo("authentication/login");
    }
}
