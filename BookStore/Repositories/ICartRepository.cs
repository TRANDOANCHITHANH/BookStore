using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int bookId, int soLuong);
        Task<int> Remove(int bookId);
        Task<Cart> GetUserCart(int id);
        Task<Cart> GetCart(string userId);
        Task<int> GetCartItemCount(string userId = "");
        Task<bool> DoCheckout(CheckoutModel model);
    }
}
