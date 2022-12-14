using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �{�^���̃R�}���h�𐧌䂷��R���|�[�l���g
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

    void Start()
    {
        _upArrow.onClick.AddListener(OnUpClicked);
        _downArrow.onClick.AddListener(OnDownClicked);
        _leftArrow.onClick.AddListener(OnLeftClicked);
        _rightArrow.onClick.AddListener(OnRightClicked);
    }

    void Update()
    {
        
    }

    void Run(Direction dir)
    {
        // �R�}���h�C���^�[�t�F�[�X�����������ړ��R�}���h�N���X�̃C���X�^���X�𐶐�����
        ICommand command = new MoveCommand(_cursorMove, dir);
        // �R�}���h�C���^�[�t�F�[�X�ɒ�`����Ă���Execute()���\�b�h�����s
        command.Execute();
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

    }

    void OnRedoClicked()
    {

    }

    void OnSubmitClicked()
    {

    }
}
