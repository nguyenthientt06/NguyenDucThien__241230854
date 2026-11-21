using System.ComponentModel.DataAnnotations;

namespace NguyenDucThien__241230854.Validation
{
    public class AnhFileExtensionAttribute : ValidationAttribute
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".png", ".gif", ".tiff" };

        public AnhFileExtensionAttribute()
        {
            ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string fileName && !string.IsNullOrWhiteSpace(fileName))
            {
                string ext = Path.GetExtension(fileName.Trim()).ToLowerInvariant();
                if (!AllowedExtensions.Contains(ext))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}