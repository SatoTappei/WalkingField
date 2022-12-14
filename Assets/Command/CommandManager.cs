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

    static Stack<Direction> _dirStack = new Stack<Direction>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();

        // 直前の処理として元に戻すスタックにプッシュする
        _undoStack.Push(command);
        // やり直しスタックをクリアする
        _redoStack.Clear();
    }

    public void UndoCommand()
    {
        if (_undoStack.Count > 0)
        {
            ICommand command = _undoStack.Pop();
            _redoStack.Push(command);
            command.Undo();
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
    }

    public void AddDirStack(Direction dir) => _dirStack.Push(dir);

    /// <summary>方向が格納されているスタックをリストに変換して取得する</summary>
    public List<Direction> GetDirList() => _dirStack.ToList();
}
