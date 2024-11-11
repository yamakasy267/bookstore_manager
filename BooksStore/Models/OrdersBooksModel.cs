namespace BooksStore.Models {

	public class OrdersBooksModel : BaseModel {
		public int BookId { get; set; }
		public int OrderId { get; set; }
		public BooksModel Book { get; set; }
		public OrdersModel Order { get; set; }
	}
}
