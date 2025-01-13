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
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name="Supported devices")]

        public List<int> SelectedDevices { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        [AllowNull, MaxLength(100)]
        public string Description { get; set; } = string.Empty;
       // [Required, MaxLength(150)]
        public IFormFile Cover { get; set; } = default!;

    }
}
