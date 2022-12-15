using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// コマンドを管理するクラス
/// </summary>
public class CommandManager
{
    static Stack<ICommand> _undoStack = new Stack<ICommand>();
    static Stack<ICommand> _redoStack = new Stack<ICommand>();

    static Stack<Direction> _undoDirStack = new Stack<Direction>();
    static Stack<Direction> _redoDirStack = new Stack<Direction>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();

        // 直前の処理として元に戻すスタックにプッシュする
        _undoStack.Push(command);
        // やり直しスタックをクリアする
        _redoStack.Clear();
    }

    public void AddDirStack(Direction dir)
    {
        _undoDirStack.Push(dir);
        _redoDirStack.Clear();
    }

    public void ClearAllStack()
    {
        _undoStack.Clear();
        _redoStack.Clear();
        _undoDirStack.Clear();
        _redoDirStack.Clear();
    }

    public void UndoCommand()
    {
        if (_undoStack.Count > 0)
        {
            ICommand command = _undoStack.Pop();
            _redoStack.Push(command);
            command.Undo();
        }

        if(_undoDirStack.Count > 0)
        {
            Direction dir = _undoDirStack.Pop();
            _redoDirStack.Push(dir);
        }
    }

    public void RedoCommand()
    {
        if (_redoStack.Count > 0)
        {
            ICommand command = _redoStack.Pop();
            _undoStack.Push(command);
            command.Execute();
        }

        if (_redoDirStack.Count > 0)
        {
            Direction dir = _redoDirStack.Pop();
            _undoDirStack.Push(dir);
        }
    }

    /// <summary>方向が格納されているスタックをキュー変換して取得する</summary>
    public Queue<Direction> GetDirQueue()
    {
        Queue<Direction> q = new Queue<Direction>();

        foreach (var v in _undoDirStack.Reverse())
            q.Enqueue(v);

        return q;
    }
}
