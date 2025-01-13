using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.Models
{
    public class Device
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }=string.Empty;
        [Required,MaxLength(100)]
        public string Icon { get; set; }= string.Empty;
    }
}
