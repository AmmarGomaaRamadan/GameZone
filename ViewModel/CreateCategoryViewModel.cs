using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.ViewModel
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; } = string.Empty;
        [MaxLength(300), AllowNull]
        public string Description { get; set; } = string.Empty;
    }
}
