using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カーソルの移動を行うコンポーネント
/// </summary>
public class CursorMove : MonoBehaviour
{
    [SerializeField] float _cellSize = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(Direction dir)
    {
        Vector3 pos = transform.position;

        switch (dir)
        {
            case Direction.Up:
                pos.y += _cellSize;
                break;
            case Direction.Down:
                pos.y -= _cellSize;
                break;
            case Direction.Left:
                pos.x -= _cellSize;
                break;
            case Direction.Right:
                pos.x += _cellSize;
                break;
        }

        transform.position = pos;
    }
}
