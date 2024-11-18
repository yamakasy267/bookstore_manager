namespace BooksStore.Models {

	public class OrdersModel : BaseModel {
		public int UserId { get; set; }
		public UsersModel User { get; set; }

		public int BooksCount { get; set; }

		public float Sum { get; set; }

		public ICollection<BooksModel> Books { get; set; }
	}
}
