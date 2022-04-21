using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace OnlineChat.Services
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {     
            return connection.User?.Identity.Name;
            // или так
            //return connection.User?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
