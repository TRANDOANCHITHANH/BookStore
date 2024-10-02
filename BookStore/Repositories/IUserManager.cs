using BookStore.Models;

namespace BookStore
{
    public interface IUserManager
    {
        Task<IEnumerable<Order>> UserOrders(bool getAll = false);
        Task<Order?> GetOrderById(int id);
        Task<IEnumerable<OrderStatus>> GetOrderStatus();
        Task TogglePaymentStatus(int orderid);
    }
}