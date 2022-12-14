using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ړ����R�}���h�Ƃ��ă��b�v����N���X
/// </summary>
public class MoveCommand : ICommand
{
    /// <summary>�J�[�\���̈ړ������郁�\�b�h�������ꂽ�N���X�ւ̎Q�Ƃ���������</summary>
    CursorMove _cursorMove;
    /// <summary>����</summary>
    Direction _dir;

    public MoveCommand(CursorMove cursorMove, Direction dir)
    {
        _cursorMove = cursorMove;
        _dir = dir;
    }

    public void Execute()
    {
        _cursorMove.Move(_dir);
    }

    public void Undo()
    {
        int reverse = -(int)_dir;
        _cursorMove.Move((Direction)reverse);
    }
}
