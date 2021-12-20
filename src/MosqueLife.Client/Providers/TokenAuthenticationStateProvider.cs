using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MosqueLife.Client.Extensions;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MosqueLife.Client.Providers;

public class TokenAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public TokenAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("token");
        var identity = string.IsNullOrWhiteSpace(token)
            ? new ClaimsIdentity()
            : new ClaimsIdentity(token.ParseClaimsFromJwt(), "jwt");

        _ = long.TryParse(identity.Claims.FirstOrDefault(a => a.Type == "exp")?.Value, out long expiry);
        var nowTicks = DateTime.Now;
        if (DateTimeOffset.FromUnixTimeSeconds(expiry).ToLocalTime() > nowTicks)
        {
            _httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrWhiteSpace(token)
                ? null
                : new AuthenticationHeaderValue("bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(identity));
        } else
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }

    }

    public async Task Login(string token)
    {
        await _localStorage.SetItemAsync("token", token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
