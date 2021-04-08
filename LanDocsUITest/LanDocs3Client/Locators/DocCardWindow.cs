using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс содержит методы и объекты для работы с окном документа на закладке Документ.
    /// </summary>
    class DocCardWindow : BaseControl
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

        /// <summary>
        /// Окно документа.
        /// </summary>
        public DocCardWindow() : base("Окно документа")
        {
            _docCardWindow = new WinWindow();
            Wait();
        }

        /// <summary>
        /// Вводит значение в поле Дата регистрации.
        /// </summary>
        /// <param name="regDate">
        /// Значение даты регистрации.
        /// </param>
        /// <returns>
        /// Возвращает введенное значение.
        /// </returns>
        public string EnterRegDate(string regDate)
        {
            FindRegDate();
            Keyboard.SendKeys(_regDate, regDate);
            return regDate;
        }

        /// <summary>
        /// Вводит значение в поле Рег. номер.
        /// </summary>
        /// <param name="regNumber">
        /// Значение регистрационного номера.
        /// </param>
        /// <returns>
        /// Возвращает введенное значение.
        /// </returns>
        public string EnterRegNumber(string regNumber)
        {
            FindRegNumber();
            Keyboard.SendKeys(_regNumber, regNumber);
            return regNumber;
        }

        /// <summary>
        /// Вводит значение в поле Краткое содержание.
        /// </summary>
        /// <param name="description">
        /// Значение для поля краткого содержания.
        /// </param>
        /// <returns>
        /// Возвращает введенное значение.
        /// </returns>
        public string EnterDescription(string description)
        {
            FindDescription();
            Keyboard.SendKeys(_docDescription, description);
            return description;
        }

        /// <summary>
        /// Получает значение Name поля Дата регистрации.
        /// </summary>
        /// <returns>
        /// Возвращает значение в поле Дата регистрации.
        /// </returns>
        public string GetRegDate()
        {
            FindRegDate();
            return _regDate.GetProperty("Name").ToString();
        }

        /// <summary>
        /// Получает значение Text поля Регистрационный номер.
        /// </summary>
        /// <returns>
        /// Возвращает значение в поле Регистрационный номер.
        /// </returns>
        public string GetRegNumber()
        {
            FindRegNumber();
            return _regNumber.GetProperty("Text").ToString();
        }

        /// <summary>
        /// Получает значение Text поля Краткое содержание.
        /// </summary>
        /// <returns>
        /// Возвращает значение в поле Краткое содержание.
        /// </returns>
        public string GetDescription()
        {
            FindDescription();
            return _docDescription.GetProperty("Text").ToString();
        }


        /// <summary>
        /// Переходит на закладку Файлы.
        /// </summary>
        /// <returns>
        /// Возвращает ленту меню закладки Файлы.
        /// </returns>
        public DocCardFilesMenu GoToFIlesTab()
        {
            FindTab("Файлы");
            Mouse.Click(_tab);
            return new DocCardFilesMenu(_docCardWindow);
        }

        /// <summary>
        /// Переходит на закладку Документ.
        /// </summary>
        /// <returns>
        /// Возвращает ленту меню закладки Документ.
        /// </returns>
        public WinPane GoToDocumentTab()
        {
            FindTab("Документ");
            Mouse.Click(_tab);
            return _docCardMenu;
        }

        /// <summary>
        /// Кликает на кнопку Сохранить в окне документа.
        /// </summary>
        public void ClickSaveDocButton()
        {
            FindDocSaveDocButton();
            Mouse.Click(_saveDocButton);
        }

        /// <summary>
        /// Кликает на кнопку Сохранить и закрыть в окне документа.
        /// </summary>
        public void SaveAndCloseDocCardWindow()
        {
            FindDocSaveAndCloseDocButton();
            Mouse.Click(_saveAndCloseDocButton);
        }

        /// <summary>
        /// Лента меню закладки Файлы окна документа.
        /// </summary>
        public DocCardFilesMenu DocCardFilesMenu()
        {
            return new DocCardFilesMenu(_docCardWindow);
        }

        /// <summary>
        /// Закладка Файлы окна документа.
        /// </summary>
        public DocCardFilesTab DocCardFilesTab()
        {
            return new DocCardFilesTab(_docCardWindow);
        }

        protected override bool IsPresent()
        {
            _docCardWindow.SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.Name,
                "Документ LanDocs",
                PropertyExpressionOperator.Contains));

            return _docCardWindow.TryFind();
        }


        private void FindDocCardMenu()
        {
            _docCardMenu = new WinPane(_docCardWindow);
            _docCardMenu.SearchProperties[UITestControl.PropertyNames.Name] = "Документ";
        }

        private void FindDocSaveDocButton()
        {
            FindDocCardMenu();
            _saveDocButton = new WinButton(_docCardMenu);
            _saveDocButton.SearchProperties[UITestControl.PropertyNames.Name] = "Сохранить";
        }

        private void FindDocSaveAndCloseDocButton()
        {
            FindDocCardMenu();
            _saveAndCloseDocButton = new WinButton(_docCardMenu);
            _saveAndCloseDocButton.SearchProperties[UITestControl.PropertyNames.Name] = "Сохранить и закрыть";
        }


        private void FindRegDate()
        {
            _regDateWindow = new WinWindow(_docCardWindow);
            _regDateWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "lanDocsDateTimeBox1";
            _regDate = new WinControl(_regDateWindow);
            _regDate.SearchProperties[UITestControl.PropertyNames.ControlType] = "DropDown";
        }

        private void FindRegNumber()
        {
            _regNumberWindow = new WinWindow(_docCardWindow);
            _regNumberWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "lanDocsTextBox1";
            _regNumber = new WinEdit(_regNumberWindow);
        }

        private void FindDescription()
        {
            _docDescriptionWindow = new WinWindow(_docCardWindow);
            _docDescriptionWindow.SearchProperties[WinControl.PropertyNames.ControlName] = "lanDocsTextBox3";
            _docDescription = new WinEdit(_docDescriptionWindow);
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
