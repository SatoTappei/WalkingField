using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボタンのコマンドを制御するコンポーネント
/// </summary>
public class InputCommand : MonoBehaviour
{
    [SerializeField] CursorMove _cursorMove;
    [Space(10)]
    [SerializeField] Button _upArrow;
    [SerializeField] Button _downArrow;
    [SerializeField] Button _leftArrow;
    [SerializeField] Button _rightArrow;
    [SerializeField] Button _undo;
    [SerializeField] Button _redo;
    [SerializeField] Button _submit;

    CommandManager _commandManager;

    void Start()
    {
        _upArrow.onClick.AddListener(OnUpClicked);
        _downArrow.onClick.AddListener(OnDownClicked);
        _leftArrow.onClick.AddListener(OnLeftClicked);
        _rightArrow.onClick.AddListener(OnRightClicked);
        _undo.onClick.AddListener(OnUndoClicked);
        _redo.onClick.AddListener(OnRedoClicked);

        _commandManager = new CommandManager();
    }

    void Update()
    {
        
    }

    void Run(Direction dir)
    {
        // コマンドインターフェースを実装した移動コマンドクラスのインスタンスを生成する
        ICommand command = new MoveCommand(_cursorMove, dir);
        // 直接するのではなくコマンドマネージャーのメソッドで呼ぶ
        _commandManager.Execute(command);
    }

    void OnUpClicked()
    {
        Run(Direction.Up);
    }

    void OnDownClicked()
    {
        Run(Direction.Down);
    }

    void OnLeftClicked()
    {
        Run(Direction.Left);
    }

    void OnRightClicked()
    {
        Run(Direction.Right);
    }

    void OnUndoClicked()
    {
        _commandManager.UndoCommand();
    }

    void OnRedoClicked()
    {
        _commandManager.RedoCommand();
    }

    void OnSubmitClicked()
    {

    }
}
