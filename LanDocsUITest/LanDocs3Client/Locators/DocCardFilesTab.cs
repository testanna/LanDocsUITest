using System;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс содержит методы и объекты для работы с закладкой Файлы окно документа.
    /// </summary>
    class DocCardFilesTab : BaseControl
    {
        private readonly WinWindow _docCardFilesTab;
        private WinCell _file;

        /// <summary>
        /// Закладка Файлы окно документа.
        /// </summary>
        public DocCardFilesTab(WinWindow docCardWindow) : base("Окно документа на закладке Файлы")
        {
            _docCardFilesTab = new WinWindow(docCardWindow);
            Wait();
        }

        /// <summary>
        /// Метод проверяет, появился ли файл в таблице файлов после добавления.
        /// </summary>
        /// <param name="name">
        /// Имя файла.
        /// </param>
        /// <returns>
        /// True, если файл найдент или False, если файл не найден.
        /// </returns>
        public bool IsFileAdded(string name)
        {
            FindFile(name);
            _file.WaitForControlExist(10000);
            return _file.TryFind();
        }

        protected override Boolean IsPresent()
        {
            _docCardFilesTab.SearchProperties[WinControl.PropertyNames.ControlName] = "gcFiles";

            return _docCardFilesTab.TryFind();
        }

        private void FindFile(string name)
        {
            if (_file == null)
            {
                _file = new WinCell(_docCardFilesTab);
                _file.SearchProperties[WinCell.PropertyNames.Value] = name;
            }
   
        }
    }
}