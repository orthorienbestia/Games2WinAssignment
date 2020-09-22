using System;
using Pacman;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action<Direction> DirectionChangeCallback;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DirectionChangeCallback?.Invoke(Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            DirectionChangeCallback?.Invoke(Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DirectionChangeCallback?.Invoke(Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DirectionChangeCallback?.Invoke(Direction.Right);
        }
    }
}
