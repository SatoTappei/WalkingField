using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動を行うコンポーネント
/// </summary>
public class PlayerMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>渡されたコマンドのリストの通りに移動する</summary>
    public IEnumerator Move(List<Direction> list)
    {
        list.Reverse();

        foreach (Direction d in list)
        {
            Vector3 pos = transform.position;

            switch (d)
            {
                case Direction.Up:
                    pos.y += 1.2f;
                    break;
                case Direction.Down:
                    pos.y -= 1.2f;
                    break;
                case Direction.Left:
                    pos.x -= 1.2f;
                    break;
                case Direction.Right:
                    pos.x += 1.2f;
                    break;
            }

            transform.position = pos;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
