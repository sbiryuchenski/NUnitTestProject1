using OpenQA.Selenium;

namespace NUnitTestProject1
{
    /// <summary>
    /// Установка соответствий между названиями и локаторами
    /// </summary>
    public class UIMapper
    {
        /// <summary>
        /// Название элемента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Локатор к элементу
        /// </summary>
        public By Locator { get; set; }
    }
}
