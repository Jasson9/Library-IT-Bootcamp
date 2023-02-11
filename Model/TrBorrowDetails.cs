using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public class TrBorrowDetails
    {
        [Key] public string? borrowDetailId { get; set; }
        public string? borrowId { get; set; }
        public DateTime borrowDate { get; set; }
        public DateTime returnDate { get; set; }
        public bool isReturn { get; set; }
        public bool isLost { get; set; }
        public DateTime lostDate { get; set; }
        public bool returnType { get; set; }
    }
}
