using Library.Output;
using Library;
using Library.Helper.Request;

namespace Library.Helper.Database
{
    public class BookHelper
    {
        public LibraryDBContext dBContext;

        public BookHelper(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Book> GetAllBooks()
        {
            var returnValue = new List<Book>();
            try
            {
                var books = dBContext?.MsBook?.ToList();
                returnValue = books?.Select(book => new Book
                {
                    bookCategory = book.categoryId + book.bookId,
                    title = book.title,
                    author = book.author,
                    publisher = book.publisher,
                    isLost = book.isLost,
                    isAvailable = book.isAvailable,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnValue;
        }

        public List<SearchBook> SearchBook(SearchBookRequestDTO data)
        {
            var returnValue = new List<SearchBook>();
            try
            {
                var books = dBContext?.MsBook?.ToList();
                books = books?.Where(book => (book.categoryId + book.bookId).Contains(data.keyword) || book.title.Contains(data.keyword) || book.author.Contains(data.keyword) || book.publisher.Contains(data.keyword)).ToList();
                books = books?.Where(book => book.isLost == false && book.isAvailable == true).ToList();
                if (books.Count == 0)
                {
                    throw new Exception("No book found");
                }
                returnValue = books?.Select(book => new SearchBook
                {
                    bookCategory = book.categoryId + book.bookId,
                    title = book.title,
                    author = book.author,
                    publisher = book.publisher
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnValue;
        }
    }
}