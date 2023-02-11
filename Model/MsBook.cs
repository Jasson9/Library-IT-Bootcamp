using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public class MsBook
    {
        [Key] public string? bookId { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public string? publisher { get; set; }
        public char categoryId { get; set; }
        public bool isLost { get; set; }
        public bool isAvailable { get; set; }
    }
}
