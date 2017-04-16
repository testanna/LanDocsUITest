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
    class DocCardWindow : BaseWindow
    {
        private readonly WinWindow _docCardWindow;
        private WinPane _docCardMenu;
        private WinPane _docFilesMenu;
        private WinButton _saveDocButton;
        private WinButton _addFilesButton;
        private WinButton _addFileItem;
        private WinTabList _tabManager;
        private WinTabPage _tab;
        private WinWindow _filesWindow;
        private WinCell _file;

        public DocCardWindow() : base("Окно документа")
        {
            _docCardWindow = new WinWindow();
            Wait();
        }


        /// <summary>
        /// TODO Summary description 
        /// </summary>
        public void ClickSaveDocButton()
        {
            FindDocSaveDocButton();
            Mouse.Click(_saveDocButton);
        }


        public void GoToTab(string tabName)
        {
            FindTab(tabName);
            Mouse.Click(_tab);
        }

        public SelectFileWindow ClickAddFile()
        {
            FindAddFilesButton();
            Mouse.Click(_addFilesButton);
            FindAddFileItem();
            Mouse.Click(_addFileItem);
            return new SelectFileWindow();
        }

        public bool IsFileAdded(string name)
        {
            FindFile(name);
            Thread.Sleep(4000);
            return _file.TryFind();
        }

        protected override Boolean IsPresent()
        {
            
            _docCardWindow.SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.Name,
                    "Документ LanDocs",
                    PropertyExpressionOperator.Contains));
            
            return _docCardWindow.TryFind();
        }


        private void FindDocCardMenu()
        {
            
            if (_docCardMenu == null)
            {
                _docCardMenu = new WinPane(_docCardWindow);
                _docCardMenu.SearchProperties[UITestControl.PropertyNames.Name] = "Документ";

            }
        }


        private void FindDocSaveDocButton()
        {
            FindDocCardMenu();
            if (_saveDocButton == null)
            {
                _saveDocButton = new WinButton(_docCardMenu);
                _saveDocButton.SearchProperties[UITestControl.PropertyNames.Name] = "Сохранить";

            }
            
        }

        private void FindFilesCardMenu()
        {

            if (_docFilesMenu == null)
            {
                _docFilesMenu = new WinPane(_docCardWindow);
                _docFilesMenu.SearchProperties[UITestControl.PropertyNames.Name] = "Файлы";

            }
        }

        private void FindAddFilesButton()
        {
            FindFilesCardMenu();
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



        private void FindTabManager()
        {
            _tabManager = new WinTabList(_docCardWindow);
            _tabManager.SearchProperties[WinControl.PropertyNames.ControlName] = "tabManager";
        }

        private void FindTab(string tabName)
        {
            FindTabManager();
            _tab = new WinTabPage(_tabManager);
            _tab.SearchProperties[UITestControl.PropertyNames.Name] = tabName;
       
        }

        private void FindFile(string name)
        {
            if (_file == null)
            {
                _filesWindow = new WinWindow(_docCardWindow);
                _filesWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "gcFiles";
                _file = new WinCell(_filesWindow);
                _file.SearchProperties[WinCell.PropertyNames.Value] = name;
              
            }

        }

    }
}
