namespace Dispatcher.Web.Infrastructure.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    public class UrlAllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public UrlAllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }

        public static string GetErrorMessage => $"Unsupported Format! The allowed picture formats are: .jpg, .jpeg, .png, .gif, .bmp;";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;

            if (url != null)
            {
                var extension = Path.GetExtension(url);

                if (!this.extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
