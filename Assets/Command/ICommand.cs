using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �R�}���h���I�u�W�F�N�g�Ƃ��ă��b�v���Ă����C���^�[�t�F�[�X
/// </summary>
public interface ICommand
{
    public void Execute();
    public void Undo();
}
