using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs3Client.Pages
{
    /// <summary>
    /// Класс для работы с главным окном в разделе Документы.
    /// </summary>
    class MainWindowDocs : BaseControl
    {
        private readonly WinToolBar _mainDocsCreateBar;
        private readonly WinButton _createDocButton;

        /// <summary>
        /// Главное окно документов.
        /// </summary>
        public MainWindowDocs(WinToolBar mainDocsMenu)
            : base("Главное окно документов")
        {
            _mainDocsCreateBar = mainDocsMenu;
            _createDocButton = new WinButton(_mainDocsCreateBar);
            Wait();
        }

        /// <summary>
        /// Кликает по кнопке Создать документ.
        /// </summary>
        /// <returns>
        /// Возвращает окно создания документа.
        /// </returns>
        public DocCardWindow ClickCreateDocButton()
        {
            Mouse.Click(_createDocButton);
            return new DocCardWindow();
        }


        protected override bool IsPresent()
        {
            _createDocButton.SearchProperties[UITestControl.PropertyNames.Name] = "Создать документ";
            return _createDocButton.TryFind();
        }
    }
}
