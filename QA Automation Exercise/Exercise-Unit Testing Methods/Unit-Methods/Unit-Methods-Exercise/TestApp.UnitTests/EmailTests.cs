using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailTests
{
    // TODO: finish test
    [Test]
    public void Test_IsValidEmail_ValidEmail()
    {
        // Arrange
        string validEmail = "test@example.com";

        // Act

        bool result = Email.IsValidEmail(validEmail);

        // Assert

        Assert.IsTrue(result);
    }

    [Test]
    public void Test_IsValidEmail_InvalidEmail()
    {
        //Arrange
        string invalidEmail = "@abv.bg";

        //Act

        bool result = Email.IsValidEmail(invalidEmail);

        //Assert

        Assert.IsFalse(result);
    }

    [TestCase(" ")]
    [TestCase(null)]
    public void Test_IsValidEmail_NullInput(string email)
    {
        //Act

        bool result = Email.IsValidEmail(email);

        //Assert

        Assert.That(result, Is.False);
    }
}
