using System;
using System.Globalization;
using LanDocsUITest.LanDocs3Client.Locators;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LanDocsUITest.LanDocs3Client.AutoTests
{
    /// <summary>
    /// Тесты на создание документа.
    /// </summary>
    [CodedUITest]
    public class CreateDocTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LocalFile.SetConfigurationFile();
            LocalFile.SetSettings();
        }

        [TestMethod]
        public void SuccessCreateDocWithFile()
        {
            MainWindow mainWindow = LanDocsApplication.Start()
                .Autorization(TestData.login, TestData.password);

            mainWindow.MainTree()
                .GoToJournal(TestData.journalName);
            DocCardWindow docCardWindow = mainWindow.Docs()
                .ClickCreateDocButton();

            string docDescription = docCardWindow
                .EnterDescription("краткое содержание" 
                + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            docCardWindow.ClickSaveDocButton();

            string docRegDate = docCardWindow.GetRegDate();
            string docRegNumber = docCardWindow.GetRegNumber();

            docCardWindow.GoToFIlesTab()
                .ClickAddFile()
                .SelectFile(TestData.fileName);
            DocCardFilesTab docCardFilesTab = docCardWindow.DocCardFilesTab();

            Assert.IsTrue(docCardFilesTab.IsFileAdded(TestData.fileName), "Файл не добавлен");

            docCardWindow.GoToDocumentTab();
            docCardWindow.SaveAndCloseDocCardWindow();

            MainGrid mainGrid = mainWindow.MainGrid();
            string gridRegNumber = mainGrid.GetFirstCellValue("Рег. номер");
            string gridRegDate = mainGrid.GetFirstCellValue("Дата регистрации");
            string gridDescription = mainGrid.GetFirstCellValue("Содержание");
            string gridFiles = mainGrid.GetFirstCellValue("Файлы");

            Assert.AreEqual(docRegNumber, gridRegNumber, 
                "Некорректное значение номера регистрации в списке документов");
            Assert.AreEqual(docRegDate, gridRegDate, 
                "Некорректное значение даты регистрации в списке документов");
            Assert.AreEqual(docDescription, gridDescription,
                "Некорректное значение краткого содержания в списке документов");
            Assert.AreEqual("1", gridFiles,
                "Некорректное значение файлов в списке документов"); 
        }
    }
}
