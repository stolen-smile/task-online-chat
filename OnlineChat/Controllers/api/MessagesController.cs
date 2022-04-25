using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Data;
using OnlineChat.Models;
using System.Linq;

namespace OnlineChat.Controllers.api
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        protected Context _context;

        public MessagesController(Context context)
        {
            _context=context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(string nickNameSender, string nickNameAdressee)
        {
            var messagesBySenderToAdressee = _context.Messages.Include(m => m.Sender).
                Where(m => m.Sender.NickName == nickNameSender && m.AddresseeUser.NickName == nickNameAdressee).//OrderBy(m => m.SendTime).  
              ToList();//

            var messagesByAdresseeToSender = _context.Messages.Include(m=>m.Sender).//OrderBy(m => m.SendTime).
                Where(m => m.Sender.NickName == nickNameAdressee && m.AddresseeUser.NickName == nickNameSender).ToList();

            var messages = messagesBySenderToAdressee.Union(messagesByAdresseeToSender).
                OrderBy(m => m.SendTime);

            return Ok(messages);
            //return Ok();
        }

    }
}
