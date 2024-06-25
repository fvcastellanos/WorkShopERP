
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using WorkShopERP.Model;

namespace WorkShopERP.Services;

public class UserService
{
    private readonly AuthenticationStateProvider authenticationStateProvider;

    private readonly WorkShopERPContext dbContext;


    public UserService(AuthenticationStateProvider authenticationStateProvider,
                       WorkShopERPContext dbContext)
    {
        this.authenticationStateProvider = authenticationStateProvider;
        this.dbContext = dbContext;
    }

    public async Task<Tenant?> GetTenantAsync()
    {
        var authState = await GetAuthenticationStateAsync();

        var nameIdentifier = authState.User.Claims
            .Where(claim => claim.Type.Contains("nameidentifier"))
            .FirstOrDefault();

        var tenantValues = nameIdentifier?.Value.Split('|');

        return dbContext.Users.Where(user => user.Provider.Equals(tenantValues[0]))
            .Where(user => user.UserId.Equals(tenantValues[1]))
            .Select(user => user.Tenant)
            .FirstOrDefault();
    }

    public async Task<string?> GetTenantCodeAsync()
    {
        var tenant = await GetTenantAsync();

        return tenant?.Code;
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
