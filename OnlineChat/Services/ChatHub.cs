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


        //we send message to client
        public async Task Send(string nickName,string to, string message)
        {
            await Clients.User(to).SendAsync("Send", nickName, message);
            await Clients.User(nickName).SendAsync("Send", nickName, message);

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

        //client recive
        //public async Task Receive(string nickName, string to, string message)
        //{
        //    await Clients.All.SendAsync("Send", nickName, message);
        //}
    }
}
