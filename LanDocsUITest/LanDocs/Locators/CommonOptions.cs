using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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

    }
}
