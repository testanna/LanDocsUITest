using LanDocsUITest.LanDocs3Client.Locators;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LanDocsUITest.LanDocs3Client.AutoTests
{
    /// <summary>
    /// Тесты входа в систему.
    /// </summary>
    [CodedUITest]
    public class LoginTests
    {
        [TestMethod]
        public void SuccessLoginTest()
        {
            LoginWindow loginWindow = LanDocsApplication.Start();
            loginWindow.EnterLogin(TestData.login);
            loginWindow.EnterPassword(TestData.password);
            MainWindow mainWindow = loginWindow.ClickEnterButton();


        }
    }
}
