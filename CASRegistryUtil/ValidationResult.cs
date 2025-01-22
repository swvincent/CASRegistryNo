using System;
using System.Collections.Generic;
using System.Text;

namespace CASRegistryUtil
{
    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; set; }
        public string ValidationMessage { get; set; }
    }
}
