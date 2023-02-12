
namespace Library.Output
{
    public class BookOutput
    {
        public List<Book> payload { get; set; }
        public BookOutput(){
            payload = new List<Book>();
        }
    }

    public class Book
    {
        public string? bookCategory { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public string? publisher { get; set; }
        public bool isLost { get; set; }
        public bool isAvailable { get; set; }
    }

    public class SearchBookOutput
    {
        public List<SearchBook> payload { get; set; }
        public SearchBookOutput(){
            payload = new List<SearchBook>();
        }
    }

    public class SearchBook
    {
        public string? bookCategory { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public string? publisher { get; set; }
    }
}