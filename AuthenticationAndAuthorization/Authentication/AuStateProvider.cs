using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace AuthenticationAndAuthorization.Authentication
{
    //从HttpContext.User中获取身份验证的状态
    public class AuStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public AuStateProvider(ProtectedSessionStorage sessionStorage)
        {
                _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSesstionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSesstionStorageResult.Success ? userSesstionStorageResult.Value : null;
                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                else
                {
                    List<Claim> claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name,userSession.UserName),
                        new Claim(ClaimTypes.Role,userSession.Role)
                };
                    var claimsPrinciple = new ClaimsPrincipal(new ClaimsIdentity(claims, "MyAuth"));
                    return await Task.FromResult(new AuthenticationState(claimsPrinciple));
                }
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

        }

        //用户登入和登出的时候更新AuthenticationState
        public async Task UpdateAuthenticationState(UserSession session)
        {
            ClaimsPrincipal claimsPrincipal;

            if (session != null)
            {
                await _sessionStorage.SetAsync("UserSession",session);
                List<Claim> claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name,session.UserName),
                        new Claim(ClaimTypes.Role,session.Role)
                };
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "MyAuth"));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
