//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CASRegistryNo.UnitTests
{
    public class CasRegNoTests
    {
        [Test]
        public void Validate_ValidCasRegNo_ReturnsTrue()
        {
            var result = CasRegNo.Validate("58-08-2");

            Assert.That(result, Is.EqualTo((true, "")));
        }

        [Test]
        [TestCase("5808-2", TestName = "Validate_CasRegNoWrongFormat_ReturnsFalseAndErrorMessage")]
        [TestCase("58-08-3", TestName = "Validate_CasRegNoBadChecksum_ReturnsFalseAndErrorMessage")]
        [TestCase("", TestName = "Validate_CasRegNoEmpty_ReturnsFalseAndErrorMessage")]
        public void Validate_InvalidCasRegNo_ReturnsFalseAndErrorMessage(string casRegNo)
        {
            var result = CasRegNo.Validate(casRegNo);

            Assert.That(!result.isValid &&
                !string.IsNullOrWhiteSpace(result.errorMessage));
        }
    }
}
