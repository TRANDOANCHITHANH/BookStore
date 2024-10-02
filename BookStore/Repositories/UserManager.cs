using BookStore.Data;
using BookStore.Models;

namespace BookStore.Repositories
{
      
    public class UserManager : IUserManager
    {
        public string UserName => throw new NotImplementedException();

        public Task<Order?> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderStatus>> GetOrderStatus()
        {
            throw new NotImplementedException();
        }

        public Task TogglePaymentStatus(int orderid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> UserOrders(bool getAll = false)
        {
            throw new NotImplementedException();
        }
    }
}
