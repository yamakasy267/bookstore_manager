using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models
{
    public class Book : BaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        public float Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly DatePublication { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Genre> Genre { get; set; }

        [GraphQLIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}