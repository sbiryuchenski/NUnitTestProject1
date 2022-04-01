namespace NUnitTestProject1
{
    /// <summary>
    /// Класс с настройками приложения
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Экземпляр браузера
        /// </summary>
        public string Browser { get; set; }
        /// <summary>
        /// Нужно ли делать максимайз окна браузера
        /// </summary>
        public bool isMaximize { get; set; }
        /// <summary>
        /// Высота окна
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Ширина окна
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Адрес тестируемой страницы
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Данные авторизации. Почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Данные авторизации. Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
