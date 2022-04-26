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
                Where(m => m.Sender.NickName == nickNameSender &&
                m.AddresseeUser.NickName == nickNameAdressee
                ).
                ToList();

            var messagesByAdresseeToSender = _context.Messages.Include(m=>m.Sender).
                Where(m => m.Sender.NickName == nickNameAdressee &&
                m.AddresseeUser.NickName == nickNameSender 
                ).
                ToList();

            var messages = messagesBySenderToAdressee.Union(messagesByAdresseeToSender).
                OrderBy(m => m.SendTime.Value.Ticks);

            return Ok(messages);
        }
        [HttpDelete]
        public ActionResult Delete(int id, bool DeletedForMyself)
        {  
            var message = _context.Messages.FirstOrDefault(m => m.Id == id);
            if (message is null)
            {
                return NotFound();
            }  
                     
            if (DeletedForMyself)
            {

                message.DeletedForMyself = DeletedForMyself;
                _context.Messages.Update(message);
                                
                _context.SaveChanges();
                return NoContent();
            }
           
            _context.Messages.Remove(message);
            
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put(int id, string newText)
        {
            var message = _context.Messages.FirstOrDefault(m=>m.Id==id);
            if (message is null)
            {
                return NotFound();
            }
            message.Text = newText;

            _context.Messages.Update(message);
            _context.SaveChanges();

            return Ok(message);
        }
    }
}
