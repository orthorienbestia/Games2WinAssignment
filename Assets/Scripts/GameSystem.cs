using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] private int columns, rows;
        [SerializeField] private float cellSize;

        [SerializeField] private GameObject demoPrefab;
        [SerializeField] private Transform gridParent;
        private Grid grid;
        private void Start()
        {
            grid = new Grid(columns,rows, cellSize,this);
        }
        [ContextMenu("Display Grid")]
        private void DisplayGrid()
        {
            grid = new Grid(columns,rows, cellSize,this);
            var gridCells = grid.Cells;

            for (int row = 0; row < gridCells.GetLength(1); row++)
            {
                for (int column = 0; column < gridCells.GetLength(0); column++)
                {
                    var g = GameObject.Instantiate(demoPrefab);
                    g.transform.position = gridCells[column, row].WorldPosition;
                    g.transform.parent = gridParent;
                }
            }
        }
    }
}

