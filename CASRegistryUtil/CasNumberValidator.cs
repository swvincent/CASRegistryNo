// Copyright 2018, 2025 Scott W. Vincent
// Shared under an MIT License - see LICENSE file for details

using System;
using System.Text.RegularExpressions;

namespace CASRegistryUtil
{
    /// <summary>
    /// CAS Registry Number validation class
    /// </summary>
    /// <remarks>
    /// Validation is based on information from:
    /// https://www.cas.org/training/documentation/chemical-substances/checkdig
    /// </remarks>
    public static class CasNumberValidator
    {

        /// <summary>
        /// Validate CAS Number.
        /// </summary>
        /// <param name="casNumber">CAS Number to validate</param>
        /// <returns>Validation Result</returns>
        public static IValidationResult Validate(string casNumber)
        {
            if (MatchesCasFormat(casNumber))
            {
                int specifiedCheckDigit = ExtractCheckDigit(casNumber);
                int calcCheckDigit = CalcCheckDigit(casNumber);

                if (specifiedCheckDigit == calcCheckDigit)
                    return new ValidationResult() { IsValid = true };
                else
                    return new ValidationResult() {
                        IsValid = false,
                        ValidationMessage = $"Incorrect check digit; expected {calcCheckDigit}"
                    };
            }
            else
                return new ValidationResult()
                {
                    IsValid = false,
                    ValidationMessage = $"Incorrect format"
                };
        }

        /// <summary>
        /// Validate CAS Number.
        /// </summary>
        /// <param name="casNumber">CAS Number to validate</param>
        /// <returns>True if valid, false if not</returns>
        public static bool IsValid(string casNumber) =>
            Validate(casNumber).IsValid;

        private static bool MatchesCasFormat(string casRegNo)
        {
            // Based on http://regexlib.com/REDetails.aspx?regexp_id=1449
            // but modified to support 10 digit CAS Numbers
            return !String.IsNullOrEmpty(casRegNo) &&
                Regex.IsMatch(casRegNo, @"\b[1-9]{1}[0-9]{1,6}-\d{2}-\d\b");
        }

        private static int ExtractCheckDigit(string casRegNo) =>
            int.Parse(casRegNo.Substring(casRegNo.Length - 1, 1));

        private static int CalcCheckDigit(string casRegNo)
        {
            int subTotal = 0;

            // Remove dashes and check digit
            string casRegDigits = casRegNo.Remove(casRegNo.Length - 2)
                .Replace("-", string.Empty);

            // Iterate through numbers and build subtotal. Start in reverse order,
            // first number multiplied by 1, second by 2, etc...
            for (int counter = casRegDigits.Length - 1; counter >= 0; counter--)
            {
                int casDigit = int.Parse(casRegDigits.Substring(counter, 1));
                int multiplier = casRegDigits.Length - counter;
                subTotal += (casDigit * multiplier);
            }

            return subTotal % 10;
        }
    }
}
