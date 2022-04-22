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

        //[HttpGet("{nickName}")]
        //public ActionResult<IQueryable<Message>> Get(string nickNameSender, string)
        //{
        //    return  _context.Messages.All(u=>u.Sender.NickName==nickName);
        //}

    }
}
