using Library.Output;
using Library.Helper.Request;
using Library.Model;

namespace Library.Helper.Database
{
    public class BorrowHelper
    {
        public LibraryDBContext dBContext;

        public BorrowHelper(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public BorrowOutput Borrow(BorrowRequestDTO data)
        {
            var returnValue = new BorrowOutput();

            try
            {
                if (data.studentId == null || data.bookId == null || data.staffId == null)
                {
                    returnValue.message = "staffId, studentId and bookId cannot be null";
                    returnValue.status = 400;
                    return returnValue;
                }

                var student = dBContext?.MsStudent?.Where(
                    x => x.studentId == data.studentId).FirstOrDefault();
                if (student == null)
                {
                    returnValue.message = "studentId Not Found";
                    returnValue.status = 400;
                    return returnValue;
                }

                if (student.isBorrowing)
                {
                    returnValue.message = "student is currently borrowing a book";
                    returnValue.status = 400;
                    return returnValue;
                }

                if (student.isBlacklisted)
                {
                    returnValue.message = "student is blacklisted";
                    returnValue.status = 400;
                    return returnValue;
                }

                var book = dBContext?.MsBook?.Where(x => x.bookId == data.bookId).FirstOrDefault();
                if (book == null)
                {
                    returnValue.message = "Book not found";
                    returnValue.status = 400;
                    return returnValue;
                }

                if (book.isLost)
                {
                    returnValue.message = "Book is lost";
                    returnValue.status = 400;
                    return returnValue;
                }

                if (!book.isAvailable)
                {
                    returnValue.message = "Book is not available(Borrowed)";
                    returnValue.status = 400;
                    return returnValue;
                }

                var borrowid = (int.Parse(dBContext?.TrBorrow?.OrderBy(x => x.borrowId).LastOrDefault()?.borrowId) + 1).ToString().PadLeft(5, '0');
                var newborrow = new TrBorrow
                {
                    bookId = data.bookId,
                    borrowId = borrowid,
                    staffId = data.staffId,
                    studentId = data.studentId
                };
                Console.WriteLine(DateTime.Now);
                var newborrowdetail = new TrBorrowDetails
                {
                    borrowId = borrowid,
                    borrowDate = DateTime.Now,
                    returnType = false,
                    borrowDetailId = (int.Parse(dBContext?.TrBorrowDetails?.OrderBy(x => x.borrowDetailId).LastOrDefault()?.borrowDetailId) + 1).ToString().PadLeft(5, '0'),
                    isLost = false,
                    isReturn = false
                };
                book.isAvailable = false;
                student.isBorrowing = true;
                dBContext?.TrBorrow?.Add(newborrow);
                dBContext?.TrBorrowDetails?.Add(newborrowdetail);
                dBContext?.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnValue;
        }
    }
}
