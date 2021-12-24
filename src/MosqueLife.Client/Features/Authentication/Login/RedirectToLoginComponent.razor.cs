using Microsoft.AspNetCore.Components;

namespace MosqueLife.Client.Features.Authentication.Login;

public partial class RedirectToLogin : ComponentBase 
{

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {
        NavigationManager.NavigateTo("authentication/login");
    }
}
