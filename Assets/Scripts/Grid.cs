using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class Grid
    {
        private int _coloumns, _rows;

        public float CellSize { get; }

        private Vector3 _worldSpace;

        public GridCell[,] Cells { get;}

        private GameSystem gameSystem;

        public Grid(int coloumns, int rows, float cellSize, GameSystem gameSystem)
        {
            this._coloumns = coloumns;
            this._rows = rows;
            this.CellSize = cellSize;
            this._worldSpace = gameSystem.transform.position;
            this.gameSystem = gameSystem;

            Cells = new GridCell[coloumns, rows];
            
            InitCells();
        }

        private void InitCells()
        {
            Vector3 startPos = _worldSpace - Vector3.right * (_coloumns/2f) * CellSize + Vector3.up * (_rows/2f) * CellSize;

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _coloumns; column++)
                {
                    Cells[column, row] = new GridCell(this)
                    {
                        WorldPosition = new Vector3(startPos.x + column * CellSize + CellSize / 2,
                            startPos.y - row * CellSize - CellSize / 2,
                            startPos.z)
                    };
                }
            }
        }
    }
}