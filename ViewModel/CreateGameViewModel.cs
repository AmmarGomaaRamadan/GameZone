using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.ViewModel
{
    public class CreateGameViewModel
    {
       
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Display(Name="Categories")]
         [Required]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        [Display(Name="Supported devices")]
        public List<int> SelectedDevices { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> GameDevices { get; set; } = new List<SelectListItem>();
        [Required, MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [AllowedFileExtension(Settings.AllowedExtensions), AllowedFileSize(Settings.AllowedInbyts)]
        public IFormFile Cover { get; set; } = default!;

    }
}
