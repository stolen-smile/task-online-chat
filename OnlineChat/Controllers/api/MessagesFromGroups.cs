using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Data;
using OnlineChat.Models;

namespace OnlineChat.Controllers.api
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesFromGroups:ControllerBase
    {
        protected Context _context;
        public MessagesFromGroups(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(string groupName)
        {
            //var group = _context.Groups.Include(m=>m.MessagesInGroup).
             //   FirstOrDefault(g => g.GroupName == groupName);

            var messages = _context.Messages.Include(m=>m.Sender).Where(m=>m.AddresseeGroup.GroupName==groupName);
            //var messages = group.MessagesInGroup.OrderBy(t => t.SendTime).ToList();
            return Ok(messages);
            //return Ok();
        }
    }
}
