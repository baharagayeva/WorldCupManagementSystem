using System.Collections.Generic;

namespace WorldCupManagementSystem
{
    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; }

        public List<string> Errors { get; }
        public ValidationResult(List<string> errors, bool isValid):this(isValid)
        {
            Errors = errors;
        }

        public ValidationResult(bool isValid) 
        { 
            IsValid = isValid;
        }
    }
}
