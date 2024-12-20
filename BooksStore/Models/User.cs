﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models {

	public class User : BaseModel {

		[Column ( TypeName = "varchar(200)" )]
		public string Name { get; set; }

		[Column ( TypeName = "varchar(200)" )]
		public string SecondName { get; set; }

		[DataType ( DataType.Date )]
		[DisplayFormat ( DataFormatString = "{0:dd:MM:yyyy}" , ApplyFormatInEditMode = true )]
		public DateTime Birtday { get; set; }

		[Column ( TypeName = "varchar(200)" )]
		[DataType ( DataType.EmailAddress )]
		public string Email { get; set; }

		[Column ( TypeName = "varchar(255)" )]
		[DataType ( DataType.Password )]
		[GraphQLName ( "Password" )]
		public string HashPassword { get; set; }

		[GraphQLIgnore]
		public virtual ICollection<Order> Orders { get; set; }
	}
}
