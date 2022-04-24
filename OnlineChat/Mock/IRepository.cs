using OnlineChat.Models;

namespace OnlineChat.Mock
{
    public interface IRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Message> Messages { get; }

        IQueryable<Group> Groups { get; }
    }
}
