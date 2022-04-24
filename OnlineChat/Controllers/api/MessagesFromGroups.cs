using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OnlineChat.Mock;
using OnlineChat.Models;

namespace OnlineChat.Controllers.api
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesFromGroups:ControllerBase
    {
        protected IRepository _context;
        public MessagesFromGroups(IRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(string groupName)
        {
            var group = _context.Groups.
                FirstOrDefault(g => g.GroupName == groupName);
            var messages = group.MessagesInGroup.OrderBy(t=>t.SendTime).ToList();
            return Ok(messages);
        }
    }
}
