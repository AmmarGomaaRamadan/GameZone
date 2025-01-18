using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Custom_Attributes
{
    public class AllowedFileSize:ValidationAttribute
    {
        private readonly int _allowedSize;

        public AllowedFileSize(int allowedSize)
        {
            _allowedSize = allowedSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as FormFile;
            if (file is not null) 
            {
                if (file.Length > _allowedSize) 
                {
                    return new ValidationResult($"The max file size is {_allowedSize}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
