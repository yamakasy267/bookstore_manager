namespace BooksStore.Models {

	public class OrdersModel : BaseModel {
		public int UsersId { get; set; }
		public UsersModel Users { get; set; }

		public int BooksCount { get; set; }

		public float Sum { get; set; }
	}
}
