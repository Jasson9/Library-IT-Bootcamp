using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public class MsStaff
    {
        [Key] public string? staffId { get; set; }
        public string? staffName { get; set; }
    }
}
