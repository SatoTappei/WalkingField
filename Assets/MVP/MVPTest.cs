using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// MVP�p�^�[����UI���������邽�߂Ƀe�X�g�p�̒l��ێ�����
/// �ŏI�I��Merge����Ƃ��͒l��ǂ������Ɉڂ�
/// </summary>
public class MVPTest : MonoBehaviour
{
    // �o�߃^�[���A����{�^����������邽�т�+1�����\��
    ReactiveProperty<int> _progTurn = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> ProgTurn => _progTurn;

    void Start()
    {
        
    }

    void Update()
    {
        // �e�X�g�A�L�[�������ꂽ��o�߃^�[���𑝂₷
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _progTurn.Value++;
            Debug.Log("���̃^�[����");
        }
    }
}
