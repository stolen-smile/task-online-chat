using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Mock;
using OnlineChat.Models;

namespace OnlineChat.Controllers.api
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        protected IRepository _context;

        public MessagesController(IRepository context)
        {
            _context=context;
        }

        [HttpGet]
        public ActionResult<IQueryable<Message>> Get(string nickNameSender, string nickNameAdressee)
        {
            IQueryable<Message> messagesBySenderToAdressee  = _context.Messages.//OrderBy(m => m.SendTime).
                Where(m => m.Sender.NickName == nickNameSender && m.AddresseeUser.NickName == nickNameAdressee);



            IQueryable<Message> messagesByAdresseeToSender = _context.Messages.//OrderBy(m => m.SendTime).
                Where(m=> m.Sender.NickName== nickNameAdressee && m.AddresseeUser.NickName==nickNameSender);

            IQueryable < Message > messages = messagesBySenderToAdressee.Union(messagesByAdresseeToSender).
                OrderBy(m => m.SendTime);

            return Ok(messages);
        }

    }
}
