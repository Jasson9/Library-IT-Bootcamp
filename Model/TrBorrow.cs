using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public class TrBorrow
    {
        [Key] public string? borrowId { get; set; }
        public string? bookId { get; set; }
        public string? staffId { get; set; }
        public string? studentId { get; set; }
    }
}
