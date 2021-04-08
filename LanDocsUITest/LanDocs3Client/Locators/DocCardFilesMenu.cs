using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс содержит методы и объекты для работы с лентой меню окна документа на закладке Файлы.
    /// </summary>
    class DocCardFilesMenu : BaseControl
    {
        private readonly WinPane _docFilesMenu;
        private WinButton _addFilesButton;
        private WinButton _addFileItem;

        /// <summary>
        /// Лента меню окна документа на закладке Файлы.
        /// </summary>
        public DocCardFilesMenu(WinWindow docCardWindow) : 
            base("Лента меню Файлы на закладке Файлы")
        {
            _docFilesMenu = new WinPane(docCardWindow);
            Wait();
        }

        /// <summary>
        /// Выполняет действие Добавить - Файл из ленты меню на закладке Файлы.
        /// </summary>
        /// <returns>
        /// Объект SelectFileWindow - стандартное окно выбора файлов.
        /// </returns>
        public SelectFileWindow ClickAddFile()
        {
            FindAddFilesButton();
            Mouse.Click(_addFilesButton);
            FindAddFileItem();
            Mouse.Click(_addFileItem);
            return new SelectFileWindow();
        }


        protected override Boolean IsPresent()
        {
            _docFilesMenu.SearchProperties[UITestControl.PropertyNames.Name] = "Файлы";
            return _docFilesMenu.TryFind();
        }

        private void FindAddFilesButton()
        {
                _addFilesButton = new WinButton(_docFilesMenu);
                _addFilesButton.SearchProperties[UITestControl.PropertyNames.Name] = "Добавить";
        }

        private void FindAddFileItem()
        {
                _addFileItem = new WinButton(_addFilesButton);
                _addFileItem.SearchProperties[UITestControl.PropertyNames.Name] = "Файл";
        }


    }
}