using CASRegistryUtil;

namespace CASRegistryUtil.UnitTests
{
    public class CasNumberValidatorTests
    {
        [Test]
        [TestCase("58-08-2", TestName = "Validate_Caffeine_CasNumber_ReturnsTrue")]
        [TestCase("7440-57-5", TestName = "Validate_Gold_CasNumber_ReturnsTrue")]
        [TestCase("98966-86-0", TestName = "Validate_RadiumHydroxide_CasNumber_ReturnsTrue")]
        [TestCase("107949-15-5", TestName = "Validate_TerbiumIIFluoride_CasNumber_ReturnsTrue")]
        [TestCase("1234567-89-5", TestName = "Validate_MadeUp_CasNumber_ReturnsTrue")]
        public void Validate_ValidCasNumber_ReturnsSuccessfulValidationResult(string CasNumber)
        {
            var result = CasNumberValidator.Validate(CasNumber);
            Assert.That(result.IsValid, Is.EqualTo(true));
        }

        [Test]
        [TestCase("5808-2", TestName = "Validate_CasNumberWrongFormat_ReturnsFalseAndErrorMessage")]
        [TestCase("1-23-4", TestName = "Validate_CasNumberTooShort_ReturnsFalseAndErrorMessage")]
        [TestCase("01-23-4", TestName = "Validate_CasNumberStartsWithZero_ReturnsFalseAndErrorMessage")]
        [TestCase("12345678-90-1", TestName = "Validate_CasNumber1stSegmentTooLong_ReturnsFalseAndErrorMessage")]
        [TestCase("1234567-900-1", TestName = "Validate_CasNumber2ndSegmentTooLong_ReturnsFalseAndErrorMessage")]
        [TestCase("1234567-90-10", TestName = "Validate_CasNumber3rdSegmentTooLong_ReturnsFalseAndErrorMessage")]
        [TestCase("58-08-3", TestName = "Validate_CasNumberBadChecksum_ReturnsFalseAndErrorMessage")]
        [TestCase("", TestName = "Validate_CasNumberEmpty_ReturnsFalseAndErrorMessage")]
        public void Validate_InvalidCasNumber_ReturnsFailedValidationResult(string CasNumber)
        {
            var result = CasNumberValidator.Validate(CasNumber);

            Assert.That(result.IsValid, Is.EqualTo(false));
            Assert.That(result.ValidationMessage, Is.Not.Null);
            Assert.That(result.ValidationMessage, Is.Not.Empty);
        }

        [Test]
        public void Validate_ValidCasNumber_IsValid_true() =>
            Assert.That(CasNumberValidator.IsValid("58-08-2") == true);

        [Test]
        public void Validate_InvalidCasNumber_IsValid_false() =>
            Assert.That(CasNumberValidator.IsValid("58-08-5") == false);
    }
}
