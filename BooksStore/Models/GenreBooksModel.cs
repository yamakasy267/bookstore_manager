namespace BooksStore.Models {

	public class GenreBooksModel : BaseModel {
		public int BookId { get; set; }
		public int GenreId { get; set; }
		public BooksModel Book { get; set; }
		public GenreModel Genre { get; set; }
	}
}
