namespace BooksStore.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }

        [GraphQLIgnore]
        public User User { get; set; }

        [GraphQLIgnore]
        public int BooksCount { get; set; }

        public float Sum { get; set; }

        [GraphQLIgnore]
        public ICollection<Book> Books { get; set; }
    }
}