namespace Dispatcher.Data.Common.CustomAttributes
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

        public string GetErrorMessage => $"This photo extension is not allowed!";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;

            if (url != null)
            {
                var extension = Path.GetExtension(url);

                if (!this.extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(this.GetErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
