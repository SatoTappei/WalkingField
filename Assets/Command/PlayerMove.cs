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
    public void Move(List<Direction> list)
    {
        list.ForEach(ac =>
        {
            switch (ac)
            {
                case Direction.Up:
                    break;
                case Direction.Down:
                    break;
                case Direction.Left:
                    break;
                case Direction.Right:
                    break;
            }
        });
    }
}
