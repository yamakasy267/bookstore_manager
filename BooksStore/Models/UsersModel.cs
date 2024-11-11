using System.ComponentModel.DataAnnotations;

namespace BooksStore.Models {

	public class UsersModel : BaseModel {
		public string Name { get; set; }

		public string SecondName { get; set; }

		[DataType ( DataType.Date )]
		[DisplayFormat ( DataFormatString = "{0:dd:MM:yyyy}" , ApplyFormatInEditMode = true )]
		public DataType Birtday { get; set; }

		[DataType ( DataType.EmailAddress )]
		public DataType Email { get; set; }

		[DataType ( DataType.Password )]
		public DataType HashPassword { get; set; }

		public ICollection<OrdersModel> Orders { get; set; }
	}
}
