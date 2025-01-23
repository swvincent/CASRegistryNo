using System;
using System.Collections.Generic;
using System.Text;

namespace CASRegistryUtil
{
    public class ValidationResult : IValidationResult
    {
        public ValidationResult(bool isValid, string validationMessage)
        {
            IsValid = isValid;
            ValidationMessage = validationMessage;
        }

        public ValidationResult(bool isValid) : this(isValid, null) { }

        public bool IsValid { get; private set; }
        public string ValidationMessage { get; private set; }
    }
}
