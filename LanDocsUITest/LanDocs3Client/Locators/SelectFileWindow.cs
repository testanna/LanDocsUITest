using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс для работы с окном выбора файлов.
    /// </summary>
    class SelectFileWindow : BaseControl
    {
        private readonly WinWindow _selectFileWindow;
        private WinEdit _fileName;
        private WinButton _openButton;

        /// <summary>
        /// Окно выбора файлов.
        /// </summary>
        public SelectFileWindow() : base("Окно выбора файла")
        {
            _selectFileWindow = new WinWindow();
            Wait();
        }

        /// <summary>
        /// Выбирает файл и нажимает кнопку Открыть.
        /// </summary>
        /// <param name="name">
        /// Имя файла.
        /// </param>
        public void SelectFile(string name)
        {
            Keyboard.SendKeys(FindFileName(), name);
            FindOpenButton();
            Mouse.Click(_openButton);
        }


        protected override bool IsPresent()
        {
            _selectFileWindow.SearchProperties.Add(UITestControl.PropertyNames.Name, "Открытие");
            return _selectFileWindow.TryFind();
        }


        private WinEdit FindFileName()
        {
            _fileName = new WinEdit(_selectFileWindow);
            _fileName.SearchProperties[UITestControl.PropertyNames.Name] = "Имя файла:";
            return _fileName;
        }

        private void FindOpenButton()
        {
            _openButton = new WinButton(_selectFileWindow);
            _openButton.SearchProperties[UITestControl.PropertyNames.Name] = "Открыть";
        }

    }
}