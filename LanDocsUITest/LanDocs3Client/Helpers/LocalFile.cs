using System;
using System.IO;

namespace LanDocsUITest.LanDocs3Client.Helpers
{
    /// <summary>
    /// Класс содержит общие методы работы с файлами на локальном диске.
    /// </summary>
    class LocalFile     
    {
        /// <summary>
        /// Метод заменяет конфигурационный файл клиента LanDocs3.exe.config.
        /// В LanDocs3.exe.config должен быть прописан СП и значение SecurytyEnabled = "False".
        /// </summary>
        public static void SetConfigurationFile()
        {
            File.Delete(TestData.configurationFilePath+TestData.configurationFileName);
            File.Copy(TestData.testDataDir + TestData.configurationFileName, TestData.configurationFilePath + TestData.configurationFileName);
            
        }

        /// <summary>
        /// Метод заменяет файлы пользовательских настроек на необходимые для тестирования.
        /// В настройках прописывается имя пользователя, все узлы главного дерева свернуты, 
        /// вид отображения файлов - таблица, в журнале установлена сортировка по дате регистрации по убыванию.
        /// </summary>
        public static void SetSettings()
        {
            string currenUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string settingsPath = currenUser + "\\AppData\\Local\\LANIT\\LanDocs\\" + TestData.currentVersion;
            string appSettingsPath = settingsPath + "\\AppSettings.xml";
            string userSettingsPath = settingsPath + "\\UserSettings.xml";
            
            File.Delete(appSettingsPath);
            File.Delete(userSettingsPath);
            File.Copy(TestData.testDataDir + "AppSettings.xml", appSettingsPath);
            File.Copy(TestData.testDataDir + "UserSettings.xml", userSettingsPath);
        }
    }
}
