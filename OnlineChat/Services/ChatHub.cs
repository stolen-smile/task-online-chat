using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineChat.Services
{
    [Authorize]
    public class ChatHub : Hub
    {
        
        //client send
        public async Task Send(string nickName,string to, string message)
        {
            await Clients.User(to).SendAsync("Send", nickName, message);
            await Clients.User(nickName).SendAsync("Send", nickName, message);
        }
        //client recive
        //public async Task Receive(string nickName, string message)
        //{
        //    await Clients.All.SendAsync("Send", nickName, message);
        //}
    }
}
