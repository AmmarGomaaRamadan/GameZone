using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }=string.Empty;
        [AllowNull,MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [Required,MaxLength(150)]
        public string Cover { get; set; } = string.Empty;
        [ Required]
        public int CategoryId { get; set; } 
        public Category Category { get; set; } = default!;
        [Required]
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();   
    }
}
