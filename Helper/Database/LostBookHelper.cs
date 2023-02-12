using Library.Output;
using Library;
using Library.Helper.Request;
using Library.Model;

namespace Library.Helper.Database
{
    public class LostBookHelper
    {
        public LibraryDBContext dBContext;

        public LostBookHelper(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public LostBookOutput addLostRecord(LostBookRequestDTO data)
        {
            var returnValue = new LostBookOutput();
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

                var book = dBContext?.MsBook?.Where(x => x.bookId == data.bookId).FirstOrDefault();
                if (book == null)
                {
                    returnValue.message = "Book not found";
                    returnValue.status = 400;
                    return returnValue;
                }

                var staff = dBContext?.MsStaff?.Where(x => x.staffId == data.staffId).FirstOrDefault();
                if (staff == null)
                {
                    returnValue.message = "Invalid Staff Id";
                    returnValue.status = 400;
                    return returnValue;
                }

                var borrow = dBContext?.TrBorrow?
                    .OrderBy(x => x.borrowId)
                    .Where(x => x.studentId == data.studentId && x.bookId == data.bookId).Last();
                var borrowdetails = dBContext?.TrBorrowDetails?
                    .Where(x => x.borrowId == borrow.borrowId && x.isReturn == false && x.isLost == false)
                    .FirstOrDefault();

                if(borrowdetails == null)
                {
                    returnValue.message = "Borrow records not found";
                    returnValue.status = 400;
                    return returnValue;
                }

                borrowdetails.isLost = true;
                if(data.lostDate == null)
                {
                    borrowdetails.lostDate = DateTime.Now;
                }
                else
                {
                    borrowdetails.lostDate = (DateTime)data.lostDate;
                }

                book.isLost = true;
                student.isBlacklisted = true;
                //Console.WriteLine(dBContext?.ChangeTracker.DebugView.LongView);
                dBContext?.SaveChanges(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnValue;
        }
    }

}