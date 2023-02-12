using Library.Output;
using Library;

namespace Library.Helper.Database
{
    public class StaffHelper
    {
        public LibraryDBContext dBContext;

        public StaffHelper(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Staff> GetAllStaffs()
        {
            var returnValue = new List<Staff>();

            try
            {
                var staffs = dBContext?.MsStaff?.ToList();

                returnValue = staffs?.Select(staff => new Staff
                {
                    staffId = staff.staffId,
                    staffName = staff.staffName
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