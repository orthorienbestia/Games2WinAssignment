using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    [RequireComponent(typeof(InputManager))]
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] private int columns, rows;
        [SerializeField] private float cellSize;

        [SerializeField] private GameObject demoPrefab;
        private Transform gridParent;
        private Grid grid;

        private GameObject PlayerPrefab;

        private Player _player;
        private InputManager inputManager;
        
        private void Awake()
        {
            PlayerPrefab = Resources.Load<GameObject>("Player");
            
            inputManager = GetComponent<InputManager>();
        }

        private void Start()
        {
            InitializeLevel();
            inputManager.DirectionChangeCallback += (direction) =>_player.NextDirection = direction;
        }

        void InitializeLevel()
        {
            gridParent = new GameObject("Grid Parent").transform;
            gridParent.parent = transform;
            gridParent.position = Vector3.zero;
            
            grid = new Grid(columns,rows, cellSize,this);

            _player = GameObject.Instantiate(PlayerPrefab).GetComponent<Player>();
            _player.Init(grid,grid.Cells[0,0]);
            DisplayCellBG();
        }

        private void DisplayCellBG()
        {
            var cellBG = Resources.Load<GameObject>("CellBG");
            var parent = new GameObject("Wall Parent").transform;
            parent.parent = transform;
            parent.position = Vector3.zero;
            grid = new Grid(columns,rows, cellSize,this);
            var gridCells = grid.Cells;

            for (int row = 0; row < gridCells.GetLength(1); row++)
            {
                for (int column = 0; column < gridCells.GetLength(0); column++)
                {
                    var g = GameObject.Instantiate(cellBG);
                    g.transform.position = gridCells[column, row].WorldPosition;
                    var pos =g.transform.position;
                    pos = new Vector3(pos.x,pos.y,2);
                    g.transform.position = pos;
                    g.transform.parent = parent;
                    g.transform.localScale = Vector3.one*cellSize;
                }
            }
        }

        [ContextMenu("Display All Walls")]
        private void DisplayGrid()
        {
            var parent = new GameObject("Wall Parent").transform;
            parent.parent = transform;
            parent.position = Vector3.zero;
            grid = new Grid(columns,rows, cellSize,this);
            var gridCells = grid.Cells;

            for (int row = 0; row < gridCells.GetLength(1); row++)
            {
                for (int column = 0; column < gridCells.GetLength(0); column++)
                {
                    var g = GameObject.Instantiate(demoPrefab);
                    g.transform.position = gridCells[column, row].WorldPosition;
                    g.transform.parent = parent;
                }
            }
        }
    }
}

