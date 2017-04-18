using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

using LanDocsUITest.LanDocs.Locators;


namespace LanDocsUITest.LanDocs.AutoTests
{
    /// <summary>
    /// TODO Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CreateDocTests
    {
        [TestInitialize]
        public void Initialize()
        {
            CommonOptions commonOptions = new CommonOptions();
            commonOptions.SetConfigurationFile();
            commonOptions.SetSettings();
        }

        [TestMethod]
        public void CreateDocWithFileTest()
        {
            LoginWindow loginWindow = LanDocsApplication.Start();
            loginWindow.EnterLogin(TestData.login);
            loginWindow.EnterPassword(TestData.password);
            MainWindow mainWindow = loginWindow.ClickEnterButton();
            MainTree mainTree = mainWindow.MainTree();
            mainTree.GoToJournal(TestData.journalName);
            MainWindowDocs mainWindowDocs = mainWindow.Docs();
            DocCardWindow docCardWindow = mainWindowDocs.ClickCreateDocButton();
            docCardWindow.ClickSaveDocButton();
            DocCardFilesMenu docCardFilesMenu = docCardWindow.GoToFIlesTab();
            SelectFileWindow selectFileWindow = docCardFilesMenu.ClickAddFile();
            selectFileWindow.SelectFile(TestData.fileName);
            DocCardFilesTab docCardFilesTab = docCardWindow.DocCardFilesTab();
            Assert.IsTrue(docCardFilesTab.IsFileAdded("TestDoc.docx"), "Файл не добавлен");
            
        }
    }
}
