namespace BooksStore.Models {

	public class BaseModel {

		[GraphQLIgnore]
		public int Id { get; set; }
	}
}
