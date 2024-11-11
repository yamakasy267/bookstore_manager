namespace BooksStore.Models {

	public class BooksModel : BaseModel {
		public string Name { get; set; }

		public AuthorModel Author { get; set; }

		public float Price { get; set; }

		public DateOnly DatePublication { get; set; }
	}
}
