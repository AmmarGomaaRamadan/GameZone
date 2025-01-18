using System.ComponentModel.DataAnnotations;

namespace GameZone.Custom_Attributes
{
    public class AllowedFileExtension:ValidationAttribute
    {
        private readonly string _allowedExtensions;
        public AllowedFileExtension(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as FormFile;
            if (file is not null)
            {
                var isAllowed = _allowedExtensions.Split(',').Contains(Path.GetExtension(file.FileName), StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                {
                    return new ValidationResult($"The permitted file extensions are {_allowedExtensions}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
