using System.ComponentModel.DataAnnotations;

namespace BooksStore.Models {

	public class AuthorModel : BaseModel {
		public string Name { get; set; }

		[DataType ( DataType.Date )]
		[DisplayFormat ( DataFormatString = "{0:dd:MM:yyyy}" , ApplyFormatInEditMode = true )]
		public DataType Birtday { get; set; }

		[DataType ( DataType.Text )]
		public DataType? Biografy { get; set; }

		public virtual ICollection<BooksModel> Books { get; set; }
	}
}
