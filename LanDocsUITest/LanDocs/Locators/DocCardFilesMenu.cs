using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs.Locators
{
    class DocCardFilesMenu : BaseWindow
    {
        private readonly WinPane _docFilesMenu;
        private WinButton _addFilesButton;
        private WinButton _addFileItem;

        public DocCardFilesMenu(WinWindow docCardWindow) : base("Лента меню Файлы на закладке Файлы")
        {
            _docFilesMenu = new WinPane(docCardWindow);
            Wait();
        }

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
            if (_addFilesButton == null)
            {
                _addFilesButton = new WinButton(_docFilesMenu);
                _addFilesButton.SearchProperties[UITestControl.PropertyNames.Name] = "Добавить";
            }
        }

        private void FindAddFileItem()
        {
            if (_addFileItem == null)
            {

                _addFileItem = new WinButton(_addFilesButton);
                _addFileItem.SearchProperties[UITestControl.PropertyNames.Name] = "Файл";

            }
        }


    }
}