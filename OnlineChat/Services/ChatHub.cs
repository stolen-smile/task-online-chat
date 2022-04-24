using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OnlineChat.Mock;
using System.Security.Claims;
using System.Threading.Tasks;
using OnlineChat.Models;
namespace OnlineChat.Services
{
    [Authorize]
    public class ChatHub : Hub
    {
        protected IRepository _context;

        public ChatHub(IRepository context)
        {
            _context = context;
            
        }

        public override Task OnConnectedAsync()
        {
            var user = _context.Users.SingleOrDefault(u=>u.NickName==Context.User.Identity.Name);
            if(user is null)
            {
                return base.OnConnectedAsync();
            } else
            if(user.Groups is null)
            {
                return base.OnConnectedAsync();
            }

            foreach(var g in user.Groups)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, g.GroupName);
            }

            //Groups.Add(Context.ConnectionId, item.RoomName);
            return base.OnConnectedAsync();
        }
        public async Task Send(string nickName,string to, string message)
        {
            await Clients.User(to).SendAsync("Recieve", nickName, message);
            await Clients.User(nickName).SendAsync("Recieve", nickName, message);

            User sender = _context.Users.FirstOrDefault(m => m.NickName == nickName);
            User adressee = _context.Users.FirstOrDefault(m => m.NickName == to);


            Message newMessage = new Message()
            {
                Text = message,
                SendTime = DateTime.Now,
                Sender = sender,
                AddresseeUser = adressee,
                AddresseeGroup = null,
            };

            sender.Messages.Add(newMessage);
            //my bezobraznye implementazii
            //_context.Messages.Append<Message>(newMessage);
            //_context.Add(newMessage);
        }

        //SendToGroups
        public async Task SendToGroups(string nickName, string groupName, string message)
        {
            
            //await initGroups();
            await Clients.Group(groupName).SendAsync("Recieve", nickName , message);
        }
    }
}
