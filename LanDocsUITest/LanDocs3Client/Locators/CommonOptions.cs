using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс содержит общие методы.
    /// </summary>
    class CommonOptions     
    {
        /// <summary>
        /// Метод заменяет конфигурационный файл клиента LanDocs3.exe.config.
        /// В LanDocs3.exe.config должен быть прописан СП и значение SecurytyEnabled = "False".
        /// </summary>
        public void SetConfigurationFile()
        {
            File.Delete(TestData.configurationFilePath+TestData.configurationFileName);
            File.Copy(TestData.testDataDir + TestData.configurationFileName, TestData.configurationFilePath + TestData.configurationFileName);
            
        }

        /// <summary>
        /// Метод заменяет файлы пользовательских настроек на необходимые для тестирования.
        /// В настройках прописывается имя пользователя, все узлы главного дерева свернуты, 
        /// вид отображения файлов - таблица, в журнале установлена сортировка по дате регистрации по убыванию.
        /// </summary>
        public void SetSettings()
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

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint flags);

        /// <summary>
        /// Метод вводит текст латинницей в поле.
        /// </summary>
        /// <param name="control">
        /// Поле для ввода текста.
        /// </param>
        /// <param name="text">
        /// Текст для ввода в поле.
        /// </param>
        public static void SendKeysEng(UITestControl control, string text)
        {
            const string lang = "00000419";
            int ret = LoadKeyboardLayout(lang, 1);
            PostMessage(GetForegroundWindow(), 0x50, 1, ret);
            Keyboard.SendKeys(control, text);
        }

    }
}
