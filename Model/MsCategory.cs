using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public class MsCategory
    {
        [Key] public string? categoryId { get; set; }
        public string? categoryName { get; set; }
    }
}