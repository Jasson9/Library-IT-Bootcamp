using Library.Output;
using Library;
using Library.Request;
using Library.Model;

namespace Library.Helper
{
    public class BookHelper
    {
        public LibraryDBContext dBContext;

        public BookHelper(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Book> FindBooks(FindBook data)
        {
            var returnValue = new List<Book>();

            try
            {
                var books = new List<MsBook>();
                switch (data.target)
                {
                    case "id":
                        books = dBContext?.MsBook?.Where(x => x.bookId == data.keyword).ToList();
                        break;
                    case "title":
                        books = dBContext?.MsBook?.Where(x => x.title.ToLower().Contains(data.keyword.ToLower())).ToList();
                        break;
                    case "author":
                        books = dBContext?.MsBook?.Where(x => x.author.ToLower().Contains(data.keyword.ToLower())).ToList();
                        break;
                    case "publisher":
                        books = dBContext?.MsBook?.Where(x => x.publisher.ToLower().Contains(data.keyword.ToLower())).ToList();
                        break;
                    default:
                        break;
                }
                var categories = dBContext?.MsCategory?.ToList();

                returnValue = books?.Join(categories,
                    book => book.categoryId,
                    category => category.categoryId,
                    (x,y) => new Book
                    {
                        id= y.categoryId.ToString()+x.bookId,
                        title=x.title,
                        author=x.author,
                        publisher=x.publisher,
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
