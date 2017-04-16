using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanDocsUITest.LanDocs.Locators
{
    class SelectFileWindow : BaseWindow
    {
        private readonly WinWindow _selectFileWindow;
        private WinEdit _fileName;
        private WinButton _openButton;

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint flags);

        public SelectFileWindow() : base("Окно выбора файла")
        {
            _selectFileWindow = new WinWindow();
            Wait();
        }

        public void SelectFile(string name)
        {
            const string lang = "00000419";
            int ret = LoadKeyboardLayout(lang, 1);
            PostMessage(GetForegroundWindow(), 0x50, 1, ret);
            FindFileName();
            Keyboard.SendKeys(name);
            FindOpenButton();
            Mouse.Click(_openButton);
        }


        protected override Boolean IsPresent()
        {

            _selectFileWindow.SearchProperties.Add(UITestControl.PropertyNames.Name, "Открытие");
            return _selectFileWindow.TryFind();

        }

        private void FindFileName()
        {
            if (_fileName == null)
            {
                _fileName = new WinEdit(_selectFileWindow);
                _fileName.SearchProperties[UITestControl.PropertyNames.Name] = "Имя файла:";

            }
        }

                private void FindOpenButton()
        {
            if (_openButton == null)
            {
                _openButton = new WinButton(_selectFileWindow);
               _openButton.SearchProperties[UITestControl.PropertyNames.Name] = "Открыть";

            }
        }
        


    }
}