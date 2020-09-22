using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class Grid
    {
        private int coloumns, rows;
        private float cellSize;
        private Vector3 worldSpace;

        private int[,] gridCells;

        private GameSystem gameSystem;

        public Grid(int coloumns, int rows, float cellSize, GameSystem gameSystem)
        {
            this.coloumns = coloumns;
            this.rows = rows;
            this.cellSize = cellSize;
            this.worldSpace = gameSystem.transform.position;
            this.gameSystem = gameSystem;

            gridCells = new int[coloumns, rows];
        }

        public Vector3[,] GetAllPositions()
        {
            Vector3[,] positions = new Vector3[coloumns, rows];

            Vector3 startPos = worldSpace - Vector3.right * (coloumns/2f) * cellSize + Vector3.up * (rows/2f) * cellSize;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < coloumns; column++)
                {
                    positions[column, row] = new Vector3(startPos.x + column * cellSize + cellSize/2, startPos.y - row * cellSize - cellSize/2,
                        startPos.z);
                }
            }

            return positions;
        }
    }
}