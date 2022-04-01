using NUnit.Framework;
using NUnitTestProject1.Common;
using NUnitTestProject1.Enums;
using NUnitTestProject1.Extensions;
using NUnitTestProject1.Models;

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    [Description("Создание тестовой среды")]
    class CreateTestEnviroment : BaseTest
    {
        User user;

        [OneTimeSetUp]
        public void Init()
        {
            user = new User()
            {
                FirstName = "Test",
                LastName = "Testov",
                Email = Context.Settings.Email,
                Password = Context.Settings.Password,
                ConfirmPassword = Context.Settings.Password,
                Gender = Gender.Male
            };
        }

        [Test, Description("Создание тестового пользователя"), Order(1)]
        public void CreateUser()
        {
            NavigationPage.Register()
                .FillAllFields(user)
                .ElementClick(Buttons.Register);
        }
    }
}
