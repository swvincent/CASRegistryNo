using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CASRegistryNo
{
    /// <summary>
    /// CAS Registry Number validation class
    /// </summary>
    /// <remarks>
    /// Validation is based on information pulled on 5/31/2018 from:
    /// http://support.cas.org/content/chemical-substances/checkdig
    /// </remarks>
    public static class CasRN
    {
        public static (bool isValid, string errorMessage) Validate(string casRegNo)
        {
            if (MatchesCasFormat(casRegNo))
            {
                int specifiedCheckDigit = ExtractCheckDigit(casRegNo);
                int calcCheckDigit = CalcCheckDigit(casRegNo);

                if (specifiedCheckDigit == calcCheckDigit)
                    return (true, "");
                else
                    return (false, $"incorrect check digit; expected {calcCheckDigit}");
            }
            else
                return (false, "incorrect format");
        }


        private static bool MatchesCasFormat(string casRegNo)
        {
            // Correct CAS number format is 2-7 digits, a dash, two digits,
            // one digit. Can't start with 0. The Reg Ex used comes from
            // http://regexlib.com/REDetails.aspx?regexp_id=1449
            // but fixed to accomodate 10-digit CAS numbers, not just 9-digit.
            return !String.IsNullOrEmpty(casRegNo) &&
                Regex.IsMatch(casRegNo, @"\b[1-9]{1}[0-9]{1,6}-\d{2}-\d\b");
        }


        private static int ExtractCheckDigit(string casRegNo)
        {
            return int.Parse(casRegNo.Substring(casRegNo.Length - 1, 1));
        }


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
                subTotal = subTotal + (casDigit * multiplier);
            }

            // The remainder of subtotal/10 is the correct check digit.
            return subTotal % 10;
        }
    }
}
