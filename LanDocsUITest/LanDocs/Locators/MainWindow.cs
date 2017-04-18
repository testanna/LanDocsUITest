using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanDocsUITest.LanDocs.Locators
{
    class MainWindow : BaseWindow
    {
        private readonly WinWindow _mainWindow;

        public MainWindow() : base("Главное окно")
        {
            _mainWindow = new WinWindow();
            Wait();
        }

        public MainWindowDocs Docs()
        {
            return new MainWindowDocs(MainMenuCreateBar());
        }

        public MainTree MainTree()
        {
            return new MainTree(_mainWindow);
        }

        public MainGrid MainGrid()
        {
            return new MainGrid(_mainWindow);
        } 


        protected override Boolean IsPresent()
        {
            _mainWindow.SearchProperties.Add(WinControl.PropertyNames.ControlName, "MainWindow");
            return _mainWindow.TryFind();           
       
        }

        private WinToolBar MainMenuCreateBar()
        {
            WinToolBar mainMenuCreateBar = new WinToolBar(_mainWindow);
            mainMenuCreateBar.SearchProperties[UITestControl.PropertyNames.Name] = "Создать";
            return mainMenuCreateBar;
        }
    }
}