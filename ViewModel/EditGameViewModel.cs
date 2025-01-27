using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModel
{
    public class EditGameViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Categories")]
        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        [Display(Name = "Supported devices")]
        public List<int> SelectedDevices { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> GameDevices { get; set; } = new List<SelectListItem>();
        [Required, MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [AllowedFileExtension(Settings.AllowedExtensions), AllowedFileSize(Settings.AllowedInbyts)]
        public string? CoverName { get; set; }
        public IFormFile? Cover { get; set; } = default!;

    }
}
