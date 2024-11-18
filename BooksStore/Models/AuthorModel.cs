using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models
{
    public class AuthorModel : BaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly Birthday { get; set; }

        [DataType(DataType.Text)]
        public string? Biografy { get; set; }

        public virtual ICollection<BooksModel> Books { get; set; }
    }
}