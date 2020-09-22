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
            var positions = grid.GetAllPositions();

            for (int row = 0; row < positions.GetLength(1); row++)
            {
                for (int column = 0; column < positions.GetLength(0); column++)
                {
                    var g = GameObject.Instantiate(demoPrefab);
                    g.transform.position = positions[column, row];
                    g.transform.parent = gridParent;
                }
            }
        }
    }
}

