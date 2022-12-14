using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動をコマンドとしてラップするクラス
/// </summary>
public class MoveCommand : ICommand
{
    /// <summary>カーソルの移動をするメソッドが書かれたクラスへの参照を持たせる</summary>
    CursorMove _cursorMove;
    /// <summary>方向</summary>
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
