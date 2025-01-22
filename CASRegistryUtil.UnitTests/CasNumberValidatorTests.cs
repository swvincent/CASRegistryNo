using CASRegistryUtil;

namespace CASRegistryUtil.UnitTests
{
    public class CasNumberValidatorTests
    {
        [Test]
        [TestCase("58-08-2", TestName = "Validate_Caffeine_CasRegNo_ReturnsTrue")]
        [TestCase("7440-57-5", TestName = "Validate_Gold_CasRegNo_ReturnsTrue")]
        [TestCase("98966-86-0", TestName = "Validate_RadiumHydroxide_CasRegNo_ReturnsTrue")]
        [TestCase("107949-15-5", TestName = "Validate_TerbiumIIFluoride_CasRegNo_ReturnsTrue")]
        [TestCase("1234567-89-5", TestName = "Validate_MadeUp_CasRegNo_ReturnsTrue")]
        public void Validate_ValidCasRegNo_ReturnsTrue(string casRegNo)
        {
            var result = CasNumberValidator.Validate(casRegNo);
            Assert.That(result, Is.EqualTo((true, "")));
        }

        [Test]
        [TestCase("5808-2", TestName = "Validate_CasRegNoWrongFormat_ReturnsFalseAndErrorMessage")]
        [TestCase("1-23-4", TestName = "Validate_CasRegNoTooShort_ReturnsFalseAndErrorMessage")]
        [TestCase("01-23-4", TestName = "Validate_CasRegNoStartsWithZero_ReturnsFalseAndErrorMessage")]
        [TestCase("12345678-90-1", TestName = "Validate_CasRegNoTooLong_ReturnsFalseAndErrorMessage")]
        [TestCase("58-08-3", TestName = "Validate_CasRegNoBadChecksum_ReturnsFalseAndErrorMessage")]
        [TestCase("", TestName = "Validate_CasRegNoEmpty_ReturnsFalseAndErrorMessage")]
        public void Validate_InvalidCasRegNo_ReturnsFalseAndErrorMessage(string casRegNo)
        {
            var result = CasNumberValidator.Validate(casRegNo);

            Assert.That(!result.isValid &&
                !string.IsNullOrWhiteSpace(result.errorMessage));
        }
    }
}
