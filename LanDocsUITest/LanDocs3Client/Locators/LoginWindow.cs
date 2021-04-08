using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс для работы с окном входа в систему.
    /// </summary>
    class LoginWindow : BaseControl
    {

        readonly WinWindow _loginWindow;
        private WinEdit _loginEdit;
        private WinEdit _passwordEdit;

        private WinButton _enterButton;

        /// <summary>
        /// Окно входа в систему.
        /// </summary>
        public LoginWindow() : base("Окно логина")
        {
            _loginWindow = new WinWindow();
            Wait();
        }

        /// <summary>
        /// Вводит значение в поле Логин. 
        /// </summary>
        /// <param name="login">
        /// Значение логина для ввода.
        /// </param>
        public void EnterLogin(String login)
        {
            Keyboard.SendKeys(_loginEdit, login);
        }

        /// <summary>
        /// Вводит значение в поле Пароль.
        /// </summary>
        /// <param name="password">
        /// Значение пароля для ввода.
        /// </param>
        public void EnterPassword(String password)
        {
            FindPasswordEdit();

            Keyboard.SendKeys(_passwordEdit, password);
        }

        /// <summary>
        /// Кликает по кнопке Вход в окне входа.
        /// </summary>
        /// <returns>
        /// Возвращает главное окно системы.
        /// </returns>
        public MainWindow ClickEnterButton()
        {
            FindEnterButton();

            Mouse.Click(_enterButton);
            
            return new MainWindow();
        }

        public MainWindow Autorization(string login, string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            return ClickEnterButton();
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
            if (_passwordEdit == null)
            {
                WinWindow passwordWindow = new WinWindow();
                passwordWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "textEditPassword";
                _passwordEdit = new WinEdit(passwordWindow);
            }
        }

        private void FindEnterButton()
        {
            if (_enterButton == null)
            {
                WinWindow enterWindow = new WinWindow();
                enterWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "btnGo";
                _enterButton = new WinButton(enterWindow);
            }
        }


    }
}
