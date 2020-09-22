using UnityEngine;

namespace Pacman
{
    public class GridCell
    {
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }

        public Vector3 WorldPosition { get; set; }

        public States _state;

        private Grid _grid;

        public GridCell(Grid grid,int columnNumber,int rowNumber)
        {
            this._grid = grid;
            ColumnNumber = columnNumber;
            RowNumber = rowNumber;
            _state = States.Empty;
        }
    }
}