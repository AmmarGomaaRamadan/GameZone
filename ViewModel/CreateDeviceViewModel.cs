using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.ViewModel
{
    public class CreateDeviceViewModel
    {
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Icon { get; set; } = string.Empty;
    }
}
