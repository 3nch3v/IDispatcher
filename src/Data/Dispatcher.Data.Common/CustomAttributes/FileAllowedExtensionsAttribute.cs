namespace Dispatcher.Data.Common.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class FileAllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public FileAllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }

        public static string GetErrorMessage => $"This photo extension is not allowed!";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!this.extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
