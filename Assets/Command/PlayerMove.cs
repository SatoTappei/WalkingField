using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動を行うコンポーネント
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _cellSize = 1;
    [SerializeField] float _speed = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>渡されたコマンドのリストの通りに移動する</summary>
    public IEnumerator Move(Queue<Direction> queue)
    {
        foreach (Direction d in queue)
        {
            Vector3 pos = transform.position;

            switch (d)
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

            yield return new WaitForSeconds(_speed);
        }
    }
}
