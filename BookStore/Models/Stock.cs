namespace BookStore.Models
{
	public class Stock
	{
		public int Id { get; set; }
		public int BookId { get; set; }
		public int Quantity { get; set; }
		public Book? book { get; set; }

	}
}
