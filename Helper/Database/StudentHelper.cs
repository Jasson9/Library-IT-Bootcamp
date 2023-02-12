using Library.Output;
using Library;

namespace Library.Helper.Database
{
    public class StudentHelper
    {
        public LibraryDBContext dBContext;

        public StudentHelper(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Student> GetAllStudents()
        {
            var returnValue = new List<Student>();

            try
            {
                var students = dBContext?.MsStudent?.ToList();

                returnValue = students?.Select(student => new Student
                {
                    id = student.studentId,
                    name = student.name,
                    isBlacklisted = student.isBlacklisted,
                    isBorrowing = student.isBorrowing
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
