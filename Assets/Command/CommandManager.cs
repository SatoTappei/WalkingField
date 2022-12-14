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

    static Stack<Direction> _dirStack = new Stack<Direction>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();

        // ���O�̏����Ƃ��Č��ɖ߂��X�^�b�N�Ƀv�b�V������
        _undoStack.Push(command);
        // ��蒼���X�^�b�N���N���A����
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

    /// <summary>�������i�[����Ă���X�^�b�N�����X�g�ɕϊ����Ď擾����</summary>
    public List<Direction> GetDirList() => _dirStack.ToList();
}
