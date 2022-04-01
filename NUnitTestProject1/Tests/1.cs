using NUnit.Framework;
using NUnitTestProject1.Common;
using NUnitTestProject1.Extensions;

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    [Description("Пробую что-нибудь")]
    class _1 : BaseTest
    {
        [Test]
        public void Test()
        {
            NavigationPage.ElementClick(Buttons.Register);

            RegistrationPage
                .ElementClick(Fields.Male)
                .ElementFill(Fields.FirstName, "Ivan")
                .ElementFill(Fields.LastName, "Baran")
                .ElementFill(Fields.Email, StringExtension.GenerateRandomEmail())
                .ElementFill(Fields.Password, "123!#$qweQWE")
                .ElementFill(Fields.Confirm, "123!#$qweQWE")
                .ElementClick(Buttons.Register);

            RegistrationPage.CheckRegisterComplete();
        }
    }
}
