using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace LanDocsUITest.LanDocs3Client.Locators
{
    /// <summary>
    /// Класс для работы со списком объектов в таблице в главном окне.
    /// </summary>
    class MainGrid: BaseControl
    {
        private readonly WinWindow _mainGrid;
        private WinRow _activeRow;
        private WinCell _cell;

        /// <summary>
        /// Таблица объектов в главном окне.
        /// </summary>
        public MainGrid(WinWindow mainWindow) : base("Список объектов в главном окне")
        {
            _mainGrid = new WinWindow(mainWindow);
            Wait();
        }

        /// <summary>
        /// Получает значение в ячейке в заданном столбце в первой строке.
        /// </summary>
        /// <param name="columnName">
        /// Имя столбца.
        /// </param>
        /// <returns> 
        /// Возвращает значение в ячейке
        /// </returns>
        public string GetFirstCellValue(string columnName)
        {
            FindFirstRow();
            return FindCellByColumnName(columnName, _activeRow).Value;
        }


        protected override Boolean IsPresent()
        {
            _mainGrid.SearchProperties.Add(WinControl.PropertyNames.ControlName, "grid");
            return _mainGrid.TryFind();
        }


        private void FindFirstRow()
        {
            if (_activeRow == null)
            {
                _activeRow = new WinRow(_mainGrid);
                _activeRow.SearchProperties.Add(UITestControl.PropertyNames.Name, "Строка 1");       
            }    
        }

        private WinCell FindCellByColumnName(string columnName, WinRow row)
        {
            if (_cell == null) 
            _cell = new WinCell(row);
            _cell.SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.Name,
                columnName, PropertyExpressionOperator.Contains));
            return _cell;
        }
    }
}