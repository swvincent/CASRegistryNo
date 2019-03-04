using NUnit.Framework;

namespace CASRegistryNo.UnitTests
{
    [TestFixture]
    public class CasRegNoTests
    {
        [Test]
        public void Validate_ValidCasRegNo_ReturnsTrue()
        {
            var result = CasRegNo.Validate("58-08-2");

            Assert.That(result, Is.EqualTo((true, "")));
        }

        [Test]
        [TestCase("5808-2")]    // Wrong format
        [TestCase("58-08-3")]   // Bad checksum
        public void Validate_InvalidCasRegNo_ReturnsFalseAndErrorMessage(string casRegNo)
        {
            var result = CasRegNo.Validate(casRegNo);

            Assert.That(!result.isValid && !string.IsNullOrWhiteSpace(result.errorMessage));
        }
    }
}
