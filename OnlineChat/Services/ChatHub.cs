using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace OnlineChat.Services
{
    [Authorize]
    public class ChatHub : Hub
    {

    }
}
