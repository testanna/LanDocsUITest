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
    internal class DocCardFilesTab : BaseWindow
    {
        private readonly WinWindow _docCardFilesTab;
        private WinCell _file;

        public DocCardFilesTab(WinWindow docCardWindow) : base("Окно документа на закладке Файлы")
        {
            _docCardFilesTab = new WinWindow(docCardWindow);
            Wait();
        }

        public bool IsFileAdded(string name)
        {
            
            FindFile(name);
            Thread.Sleep(4000);
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