using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace LanDocsUITest.LanDocs.Locators
{
    class CommonOptions
        
    {
        public void SetConfigurationFile()
        {
            File.Delete(TestData.configurationFilePath+TestData.configurationFileName);
            File.Copy(TestData.testDataDir + TestData.configurationFileName, TestData.configurationFilePath + TestData.configurationFileName);
            
        }

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

        public static void SendKeysEng(string text)
        {
            const string lang = "00000419";
            int ret = LoadKeyboardLayout(lang, 1);
            PostMessage(GetForegroundWindow(), 0x50, 1, ret);
            Keyboard.SendKeys(text);
        }

    }
}
