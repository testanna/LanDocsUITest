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
    internal class DocCardWindow : BaseWindow
    {
        private readonly WinWindow _docCardWindow;
        private WinPane _docCardMenu;
        private WinButton _saveDocButton;
        private WinTabList _tabManager;
        private WinTabPage _tab;

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

        public DocCardFilesMenu GoToFIlesTab()
        {
            FindTab("Файлы");
            Mouse.Click(_tab);
            return new DocCardFilesMenu(_docCardWindow);
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
