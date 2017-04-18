using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs.Locators
{
    internal class DocCardWindow : BaseWindow
    {
        private readonly WinWindow _docCardWindow;
        private WinPane _docCardMenu;
        private WinButton _saveDocButton;
        private WinButton _saveAndCloseDocButton;
        private WinTabList _tabManager;
        private WinTabPage _tab;
        private WinControl _regDate;
        private WinEdit _regNumber;
        private WinEdit _docDescription;
        private WinWindow _regNumberWindow;
        private WinWindow _docDescriptionWindow;
        private WinWindow _regDateWindow;

        public DocCardWindow() : base("Окно документа")
        {
            _docCardWindow = new WinWindow();
            Wait();
        }

        public string EnterRegDate(string regDate)
        {
            FindRegDate();
            Keyboard.SendKeys(_regDate, regDate);
            return regDate;
        }

        public string EnterRegNumber(string regNumber)
        {
            FindRegNumber();
            Keyboard.SendKeys(_regNumber, regNumber);
            return regNumber;
        }

        public string EnterDescription(string description)
        {
            FindDescription();
            Keyboard.SendKeys(_docDescription, description);
            return description;
        }

        public string GetRegDate()
        {
            FindRegDate();
            return _regDate.GetProperty("Name").ToString();
        }

        public string GetRegNumber()
        {
            FindRegNumber();
            return _regNumber.GetProperty("Text").ToString();
        }

        public string GetDescription()
        {
            FindDescription();
            return _docDescription.GetProperty("Text").ToString();
        }

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        public void ClickSaveDocButton()
        {
            FindDocSaveDocButton();
            Mouse.Click(_saveDocButton);
        }

        public DocCardFilesMenu GoToFIlesTab()
        {
            FindTab("Файлы");
            Mouse.Click(_tab);
            return new DocCardFilesMenu(_docCardWindow);
        }

        public WinPane GoToDocumentTab()
        {
            FindTab("Документ");
            Mouse.Click(_tab);
            return _docCardMenu;
        }


        public void SaveAndCloseDocCardWindow()
        {
           FindDocSaveAndCloseDocButton();
           Mouse.Click(_saveAndCloseDocButton);
        }


        public DocCardFilesMenu DocCardFilesMenu()
        {
            return new DocCardFilesMenu(_docCardWindow);
        }

        public DocCardFilesTab DocCardFilesTab()
        {
            return new DocCardFilesTab(_docCardWindow);
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

        private void FindDocSaveAndCloseDocButton()
        {
            FindDocCardMenu();
            if (_saveAndCloseDocButton == null)
            {
                _saveAndCloseDocButton = new WinButton(_docCardMenu);
                _saveAndCloseDocButton.SearchProperties[UITestControl.PropertyNames.Name] = "Сохранить и закрыть";
            }
        }

        private void FindRegDate()
        {
            if (_regDate == null)
            {
                _regDateWindow = new WinWindow(_docCardWindow);
                _regDateWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "lanDocsDateTimeBox1";
                _regDate = new WinControl(_regDateWindow);
                _regDate.SearchProperties[UITestControl.PropertyNames.ControlType] = "DropDown";
            }
        }

        private void FindRegNumber()
        {
            if (_regNumber == null)
            {
                _regNumberWindow = new WinWindow(_docCardWindow);
                _regNumberWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "lanDocsTextBox1";
                _regNumber = new WinEdit(_regNumberWindow);
            }
        }

        private void FindDescription()
        {
            if (_docDescription == null)
            {
                _docDescriptionWindow = new WinWindow(_docCardWindow);
                _docDescriptionWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "lanDocsTextBox3";
                _docDescription = new WinEdit(_docDescriptionWindow);
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
    }
}
