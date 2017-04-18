using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs.Locators
{
    class MainTree : BaseWindow
    {
        private readonly WinWindow _mainTree;
        private WinCell _docsCell;
        private WinCell _registrationJournalsCell;
        private WinCell _journalCell;


        public MainTree(WinWindow mainWindow) : base("Главное дерево")
        {
            _mainTree = new WinWindow(mainWindow);
            Wait();
        }

        public void GoToJournal(string journalName)
           
        {
            FindDocsCell();
            Mouse.DoubleClick(_docsCell);

            FindRegistrationJournals();
            Mouse.DoubleClick( _registrationJournalsCell);

            FindJournal(journalName);
            Mouse.Click(_journalCell);
        }

        protected override Boolean IsPresent()
        {
            
            _mainTree.SearchProperties.Add(WinControl.PropertyNames.ControlName, "_tree");
            return _mainTree.TryFind();

        }

        private void FindDocsCell()
        {

            if (_docsCell != null) return;
            _docsCell = new WinCell(_mainTree);
            _docsCell.SearchProperties[WinCell.PropertyNames.Value] = "Документы";

        }

        private void FindRegistrationJournals()
        {
            FindDocsCell();
            if (_registrationJournalsCell != null) return;
            _registrationJournalsCell = new WinCell(_mainTree);
            _registrationJournalsCell.SearchProperties["Value"] = "Журналы регистрации";


        }

        private void FindJournal(string journalName)
        {

            FindRegistrationJournals();
            if (_journalCell != null) return;
            _journalCell = new WinCell(_mainTree);
           _journalCell.SearchProperties["Value"] = journalName;
        }
    }
}
