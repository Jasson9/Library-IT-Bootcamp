namespace Library.Helper.Request
{
    public class ResolveLostBookRequestDTO
    {
        public string? studentId { get; set; }
        public string? staffId { get; set; }
        public string? bookId { get; set; }
        //public bool? Paid { get; set; }
    }
}