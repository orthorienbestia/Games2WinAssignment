using UnityEngine;

namespace Pacman
{
    public class GridCell
    {
        public Vector3 WorldPosition { get; set; }

        private States _state;

        private Grid _grid;

        public GridCell(Grid grid)
        {
            this._grid = grid;
            _state = States.Empty;
        }
    }
}