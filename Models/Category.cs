using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100),Required]
        public string Name { get; set; }=string.Empty;
        [MaxLength(300),AllowNull]
        public string Description { get; set; } = string.Empty;
    }
}
