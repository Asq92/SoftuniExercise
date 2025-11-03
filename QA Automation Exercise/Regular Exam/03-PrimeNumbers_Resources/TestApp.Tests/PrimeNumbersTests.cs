using NUnit.Framework;
using System.Security.Cryptography;

namespace TestApp.Tests
{
    public class PrimeNumbersTests
    {
        [Test]
        public void StartGreaterThanEnd_ShouldReturnErrorMessage()
        {
            //Arrange
            int startNum = 10;
            int endNum = 3;
            string expected = "Start number should be bigger than end number.";

            //Act

            string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void OneToOne_NoPrimes_ReturnsEmptyString()
        {
            //Arrange
            int startNum = 1;
            int endNum = 1;
            string expected = string.Empty;

            //Act

            string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ZeroToOne_NoPrimes_ReturnsEmptyString()
        {
            //Arrange
            int startNum = 0;
            int endNum = 1;
            string expected = string.Empty;

            //Act

            string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TwoToThree_ReturnsTwoThree()
        {
            //Arrange
            int startNum = 2;
            int endNum = 3;
            string expected = "2 3";

            //Act

            string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void OneToFifty_ReturnsAllPrimesCorrectly()
        {
            //Arrange
            int startNum = 1;
            int endNum = 50;
            string expected = "2 3 5 7 11 13 17 19 23 29 31 37 41 43 47";

            //Act

            string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

            //Assert

            Assert.AreEqual(expected, result);
        }
    }
}
