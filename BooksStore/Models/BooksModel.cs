using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models {

	public class BooksModel : BaseModel {

		[Column ( TypeName = "varchar(200)" )]
		public string Name { get; set; }

		public AuthorModel Author { get; set; }

		public float Price { get; set; }

		[DataType ( DataType.Date )]
		[DisplayFormat ( DataFormatString = "{0:dd:MM:yyyy}" , ApplyFormatInEditMode = true )]
		public DateTime DatePublication { get; set; }
	}
}
