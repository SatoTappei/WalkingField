using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̈ړ����s���R���|�[�l���g
/// </summary>
public class PlayerMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>�n���ꂽ�R�}���h�̃��X�g�̒ʂ�Ɉړ�����</summary>
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
