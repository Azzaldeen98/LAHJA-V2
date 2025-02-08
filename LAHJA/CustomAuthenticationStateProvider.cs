using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using System.Text.Json;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace LAHJA
{




    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly UserContextService _userContext;

        public NotificationService(IHubContext<NotificationHub> hubContext, UserContextService userContext)
        {
            _hubContext = hubContext;
            _userContext = userContext;
        }
        public async Task NotifyClients(string message)
        {

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

        // إرسال إشعار لمستخدم معين بناءً على معرفه
        public async Task SendAlertToUser(string userId, string message)
        {
            var connectionId = _userContext.GetConnectionId(userId);
            if (connectionId != null)
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveNotification", message);
            }
        }
    }

    public class NotificationHub : Hub
    {
        private readonly UserContextService _userContext;


        public NotificationHub(UserContextService userContext)
        {
            _userContext = userContext;

        }

        public override Task OnConnectedAsync()
        {
            var HttpContext = Context.GetHttpContext();
            var token = HttpContext?.Request.Query["access_token"].ToString();
            if (!string.IsNullOrEmpty(token))
            {
                _userContext.AddUser(token, Context.ConnectionId);


            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var HttpContext = Context.GetHttpContext();
            var token = HttpContext?.Request.Query["access_token"].ToString();
            if (!string.IsNullOrEmpty(token))
            {
                _userContext.RemoveUser(token);
            }
            return base.OnDisconnectedAsync(exception);

        }
    }


    public class UserContextService
    {
        private readonly ConcurrentDictionary<string, string> _userConnections = new();

        public void AddUser(string userId, string connectionId)
        {
            _userConnections[userId] = connectionId;
        }

        public void RemoveUser(string userId)
        {
            _userConnections.TryRemove(userId, out _);
        }

        public string? GetConnectionId(string userId)
        {
            _userConnections.TryGetValue(userId, out var connectionId);
            return connectionId;
        }
    }

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly TokenService _tokenService;
        private readonly AuthenticationState _anonymous;

        public CustomAuthenticationStateProvider(TokenService localStorage)
        {
            _tokenService = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _tokenService.GetTokenAsync();

            if (string.IsNullOrEmpty(token))
                return _anonymous;

            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "Bearer");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "Bearer");
            var user = new ClaimsPrincipal(identity);

            var authenticatedState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authenticatedState));
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            NotifyAuthenticationStateChanged(Task.FromResult(anonymousState));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = WebEncoders.Base64UrlDecode(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }
    }

}
