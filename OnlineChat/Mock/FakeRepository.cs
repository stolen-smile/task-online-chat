using OnlineChat.Models;

namespace OnlineChat.Mock
{
    public class FakeRepository : IRepository
    {
        public IQueryable<User> Users => new List<User>
        {
            new User{NickName="hottabych"},
            new User{NickName="prepared"}

        }.AsQueryable<User>();
    }
}
