using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace OnlineChat.Services
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string nickName, string message)
        {
            await Clients.All.SendAsync("Send", nickName, message);
        }
        //public async Task Receive(string nickName, string message)
        //{
        //    await Clients.All.SendAsync("Send", nickName, message);
        //}
    }
}
