namespace Library.Output
{
    public class StaffOutput
    {
        public List<Staff> payload { get; set; }
        public StaffOutput(){
            payload = new List<Staff>();
        }
    }
    public class Staff
    {
        public string? staffId { get; set; }
        public string? staffName { get; set; }
    }
}