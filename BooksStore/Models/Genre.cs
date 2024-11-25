using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models
{
    public class Genre : BaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [GraphQLIgnore]
        public ICollection<Book> Books { get; set; }
    }
}