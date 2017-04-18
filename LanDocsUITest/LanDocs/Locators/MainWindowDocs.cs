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
    class MainWindowDocs : BaseWindow
    {
        private readonly WinToolBar _mainDocsCreateBar;
        private readonly WinButton _createDocButton;

        public MainWindowDocs(WinToolBar mainDocsMenu)
            : base("Главное окно документов")
        {
            _mainDocsCreateBar = mainDocsMenu;
            _createDocButton = new WinButton(_mainDocsCreateBar);
             Wait();
        }

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        public DocCardWindow ClickCreateDocButton()
        {
            Mouse.Click(_createDocButton);
            return new DocCardWindow();
        }

        protected override Boolean IsPresent()
        {
            _createDocButton.SearchProperties[UITestControl.PropertyNames.Name] = "Создать документ";
            return _createDocButton.TryFind();
        }
    }
}
