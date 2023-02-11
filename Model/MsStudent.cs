using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public class MsStudent
    {
        [Key] public string? studentId { get; set; }
        public string? name { get; set; }
        public bool isBorrowing { get; set; }
        public bool isBlacklisted { get; set; }
    }
}
