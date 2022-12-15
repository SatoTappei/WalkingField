using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// �R�}���h���Ǘ�����N���X
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

        // ���O�̏����Ƃ��Č��ɖ߂��X�^�b�N�Ƀv�b�V������
        _undoStack.Push(command);
        // ��蒼���X�^�b�N���N���A����
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

    /// <summary>�������i�[����Ă���X�^�b�N���L���[�ϊ����Ď擾����</summary>
    public Queue<Direction> GetDirQueue()
    {
        Queue<Direction> q = new Queue<Direction>();

        foreach (var v in _undoDirStack.Reverse())
            q.Enqueue(v);

        return q;
    }
}
