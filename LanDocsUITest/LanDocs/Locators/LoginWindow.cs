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
    /// <summary>
    /// TODO Summary description 
    /// </summary>
    class LoginWindow : BaseWindow
    {

        readonly WinWindow _loginWindow;
        private WinEdit _loginEdit;
        private WinEdit _passwordEdit;

        private WinButton _enterButton;

        public LoginWindow() : base("Окно логина")
        {
            _loginWindow = new WinWindow();
            Wait();
        }

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        public void EnterLogin(String login)
        {
            Keyboard.SendKeys(_loginEdit, login);
        }

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        public void EnterPassword(String password)
        {
            FindPasswordEdit();

            Keyboard.SendKeys(_passwordEdit, password);
        }

        /// <summary>
        /// TODO Summary description 
        /// </summary>
        public MainWindow ClickEnterButton()
        {
            FindEnterButton();

            Mouse.Click(_enterButton);
            
            return new MainWindow();
        }

        public void Autorization(string login, string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            ClickEnterButton();
        }

        protected override Boolean IsPresent()
        {
            if (_loginEdit == null)
            {
                _loginWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "textEditLogin";
                _loginEdit = new WinEdit(_loginWindow);
            }

            return _loginEdit.TryFind();
        }

        private void FindPasswordEdit()
        {
            if (_passwordEdit != null) return;

            WinWindow passwordWindow = new WinWindow();
            passwordWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "textEditPassword";
            _passwordEdit = new WinEdit(passwordWindow);
        }

        private void FindEnterButton()
        {
            if (_enterButton != null) return;

            WinWindow enterWindow = new WinWindow();
            enterWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "btnGo";
            _enterButton = new WinButton(enterWindow);
        }


    }
}
