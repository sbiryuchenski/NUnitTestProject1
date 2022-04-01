using NUnitTestProject1.Enums;

namespace NUnitTestProject1.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        public Gender Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
