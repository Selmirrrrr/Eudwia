using Microsoft.AspNetCore.Components;

namespace MosqueLife.Shared.Features.Account.Login;

public partial class RedirectToLogin : ComponentBase 
{

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {
        NavigationManager.NavigateTo("authentication/login");
    }
}
