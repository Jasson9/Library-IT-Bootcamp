
namespace Library.Output
{
    public class BookListOutput
    {
        public List<Book> payload { get; set; }

        public BookListOutput(){
            payload = new List<Book>();
        }

    }

    public class Book
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public string? publisher { get; set; }
    }

}
