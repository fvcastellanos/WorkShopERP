
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace WorkShopERP.Services;

public class UserService
{
    private readonly AuthenticationStateProvider authenticationStateProvider;

    public UserService(AuthenticationStateProvider authenticationStateProvider)
    {
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<string?> GetTenantAsync()
    {
        var authState = await GetAuthenticationStateAsync();

        var tenant = authState.User.Claims
            .Where(claim => claim.Type.Contains("tenant"))
            .FirstOrDefault();

        return tenant?.Value;
    }

    public async Task<ClaimsPrincipal?> GetUserAsync()
    {
        var authState = await GetAuthenticationStateAsync();

        return authState.User;
    }

    private async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return await authenticationStateProvider.GetAuthenticationStateAsync();
    }
}
