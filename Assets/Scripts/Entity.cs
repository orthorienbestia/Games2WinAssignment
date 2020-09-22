using System;
using System.Collections;
using UnityEngine;

namespace Pacman
{
    public abstract class Entity : MonoBehaviour
    {
        protected Transform _transform;

        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }

        protected GridCell _currentCell;
        protected GridCell NextGridCell => grid.GetAdjacentGridCell(_currentCell, _currentDirection);
        protected Direction _currentDirection;
        public virtual Direction CurrentDirection
        {
            get { return _currentDirection; }
            set { _currentDirection = value; }
        }

        protected float _scalingMultiplier = 0.78f;

        protected Grid grid;
        [SerializeField] protected float _movementSpeed;

        protected virtual void Awake()
        {
            _transform = transform;
            _currentDirection = Direction.None;
        }

        /// <summary>
        /// Call always after spawning entity
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="gridCell"></param>
        public virtual void Init(Grid grid, GridCell gridCell)
        {
            this.grid = grid;
            _currentCell = gridCell;

            Position = _currentCell.WorldPosition;
        }
        
        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            MovementUpdate();
        }

        protected virtual void MovementUpdate()
        {
            
        }
    }
}