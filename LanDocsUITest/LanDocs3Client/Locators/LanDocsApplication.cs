using Microsoft.VisualStudio.TestTools.UITesting;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс для работы с приложением.
    /// </summary>
    class LanDocsApplication
    {
        /// <summary>
        /// Запускает клиент LD3.
        /// </summary>
        /// <returns>
        /// Возвращает окно входа в систему.
        /// </returns>
        public static LoginWindow Start()
        {
            ApplicationUnderTest.Launch(@"C:\Program Files (x86)\LanDocs\Client3\LanDocs3.exe");
            return new LoginWindow();
        }
    }
}
