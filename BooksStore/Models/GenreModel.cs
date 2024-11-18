using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models {

	public class GenreModel : BaseModel {

		[Column ( TypeName = "varchar(200)" )]
		public string Name { get; set; }

		[GraphQLIgnore]
		public ICollection<BooksModel> Books { get; set; }
	}
}
