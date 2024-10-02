using BookStore.Data;

namespace BookStore.Repositories
{
    public interface IUserManager
    {
        string UserName { get; }
    }
    public class UserManager : IUserManager
    {
        public string UserName => throw new NotImplementedException();
    }
}
