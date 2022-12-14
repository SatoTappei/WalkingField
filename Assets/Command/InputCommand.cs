using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボタンのコマンドを制御するコンポーネント
/// </summary>
public class InputCommand : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
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
        _submit.onClick.AddListener(OnSubmitClicked);

        _commandManager = new CommandManager();
    }

    void Update()
    {
        
    }

    void Run(Direction dir)
    {
        // コマンドインターフェースを実装した移動コマンドクラスのインスタンスを生成する
        ICommand command = new MoveCommand(dir);
        // 直接するのではなくコマンドマネージャーのメソッドで呼ぶ
        _commandManager.ExecuteCommand(command);
        // 方向をスタックに格納する
        _commandManager.AddDirStack(dir);
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
        StartCoroutine(_playerMove.Move(_commandManager.GetDirQueue()));

        // スタックをすべてクリアする
        _commandManager.ClearAllStack();
    }
}
