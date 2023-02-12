namespace Library.Helper.Request
{
    public class LostBookRequestDTO
    {
        public string? studentId { get; set; }
        public string? staffId { get; set; }
        public string? bookId { get; set; }
        public DateTime? lostDate { get; set; }
    }
}