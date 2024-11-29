namespace BooksStore.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int BooksCount { get; set; }

        public float Sum { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}