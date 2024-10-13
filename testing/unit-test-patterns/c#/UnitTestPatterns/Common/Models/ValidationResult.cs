namespace UnitTestPatterns.Common.Models
{
    public class ValidationResult
    {
        private ValidationResult(bool isValid, string message = "")
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; }
        public string Message { get; }

        public static ValidationResult IsValidResult()
        {
            return new ValidationResult(true);
        }

        public static ValidationResult IsInvalidResult(string message)
        {
            return new ValidationResult(false, message);
        }
    }
}
