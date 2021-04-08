using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс для работы с главным окном.
    /// </summary>
    class MainWindow : BaseControl
    {
        private readonly WinWindow _mainWindow;

        /// <summary>
        /// Главное окно системы.
        /// </summary>
        public MainWindow() : base("Главное окно")
        {
            _mainWindow = new WinWindow();
            Wait();
        }

        /// <summary>
        /// Главное окно - Документы.
        /// </summary>
        public MainWindowDocs Docs()
        {
            return new MainWindowDocs(MainMenuCreateBar());
        }

        /// <summary>
        /// Главное окно - Главное дерево.
        /// </summary>
        public MainTree MainTree()
        {
            return new MainTree(_mainWindow);
        }

        /// <summary>
        /// Главное окно - список объектов.
        /// </summary>
        public MainGrid MainGrid()
        {
            return new MainGrid(_mainWindow);
        }


        protected override bool IsPresent()
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