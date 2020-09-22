using System.Collections;
using UnityEngine;

namespace Pacman
{
    [RequireComponent(typeof(Animator))]
    public class Player : Entity
    {
        private Animator _animator;
        private Direction _nextDirection;

        private GameObject wallPrefab;

        public Direction NextDirection
        {
            get => _nextDirection;
            set => _nextDirection = value;
        }

        public override Direction CurrentDirection
        {
            get { return _currentDirection; }
            set
            {
                _currentDirection = value;
                _animator.SetTrigger(_currentDirection.ToString());
            }
        }

        protected override void Awake()
        {
            base.Awake();
            wallPrefab = Resources.Load<GameObject>("Wall");
        }

        public override void Init(Grid grid, GridCell gridCell)
        {
            base.Init(grid, gridCell);
            _transform.localScale =
                new Vector3(_scalingMultiplier * grid.CellSize, _scalingMultiplier * grid.CellSize, 1);
        }

        protected override void Start()
        {
            _animator = GetComponent<Animator>();
            CurrentDirection = Direction.Down;
            NextDirection = CurrentDirection;
            SpawnWall();
        }

        protected override void MovementUpdate()
        {
            if (NextGridCell == null)
            {
                CurrentDirection = NextDirection;
                return;
            }

            Position += (NextGridCell.WorldPosition - Position).normalized * _movementSpeed;
            if (Vector2.Distance(Position, NextGridCell.WorldPosition) < 0.01f)
            {
                _currentCell = NextGridCell;
                CurrentDirection = _nextDirection;
                if (_currentCell._state == States.Empty)
                {
                    _currentCell._state = States.Wall;
                    SpawnWall();
                }
            }
        }
    
        void SpawnWall()
        {
            StartCoroutine(_SpawnWall());
        }

        private WaitForSeconds wallSpawnDelay = new WaitForSeconds(0.04f);
        IEnumerator _SpawnWall()
        {
            var position = _currentCell.WorldPosition;
            yield return wallSpawnDelay;
            
            var w = Instantiate(wallPrefab, transform.parent);
            w.transform.position = position;
            w.transform.localScale = Vector3.one * (grid.CellSize * _scalingMultiplier);
        }
    }
}