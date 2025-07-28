using System.Text.RegularExpressions;

namespace ContaineRs.Domain.Models
{
    public class Email
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public Email(string value)
        {
            // Validação de email
            if (!EmailRegex.IsMatch(value))
            {
                throw new ArgumentException("E-mail inválido.", nameof(value));
            }

            Value = value; 
        }
        public string Value { get; }
    }
}
