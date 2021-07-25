﻿namespace Dispatcher.Services
{
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    using Dispatcher.Services.Contracts;

    public class StringValidatorService : IStringValidatorService
    {
        public bool IsStringValidDecoded(string input, int requiredStringLength)
        {
            string decodedString = this.HtmlDecoder(input);

            if (string.IsNullOrWhiteSpace(decodedString)
                || decodedString.Length < requiredStringLength)
            {
                return false;
            }

            return true;
        }

        private string HtmlDecoder(string input)
        {
            var result = WebUtility.HtmlDecode(Regex.Replace(input, "<[^>]+>", string.Empty)).Trim();
            byte[] bytes = Encoding.Default.GetBytes(result);
            result = Encoding.UTF8.GetString(bytes);

            return result;
        }
    }
}
