using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class Grid
    {
        private int _coloumnCount, _rowCount;

        public float CellSize { get; }

        private Vector3 _worldSpace;

        public GridCell[,] Cells { get; }

        private GameSystem gameSystem;

        public Grid(int coloumnCount, int rowCount, float cellSize, GameSystem gameSystem)
        {
            this._coloumnCount = coloumnCount;
            this._rowCount = rowCount;
            this.CellSize = cellSize;
            this._worldSpace = gameSystem.transform.position;
            this.gameSystem = gameSystem;

            Cells = new GridCell[coloumnCount, rowCount];

            InitCells();
        }

        private void InitCells()
        {
            Vector3 startPos = _worldSpace - Vector3.right * (_coloumnCount / 2f) * CellSize +
                               Vector3.up * (_rowCount / 2f) * CellSize;

            for (int row = 0; row < _rowCount; row++)
            {
                for (int column = 0; column < _coloumnCount; column++)
                {
                    Cells[column, row] = new GridCell(this, column, row)
                    {
                        WorldPosition = new Vector3(startPos.x + column * CellSize + CellSize / 2,
                            startPos.y - row * CellSize - CellSize / 2,
                            startPos.z)
                    };
                }
            }
        }

        public GridCell GetAdjacentGridCell(GridCell gridCell, Direction _direction)
        {
            int row = gridCell.RowNumber;
            int column = gridCell.ColumnNumber;

            switch (_direction)
            {
                case Direction.Up:
                    row -= 1;
                    break;
                case Direction.Down:
                    row += 1;
                    break;
                case Direction.Left:
                    column -= 1;
                    break;
                case Direction.Right:
                    column += 1;
                    break;
            }

            if (row < 0 || row >=_rowCount || column < 0 || column >= _coloumnCount)
                return null;
            return Cells[column, row];
        }
    }
}