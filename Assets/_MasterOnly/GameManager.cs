using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameManager : MonoBehaviour
{
    // �o�߃^�[���A����{�^����������邽�т�+1�����
    ReactiveProperty<int> _progTurn = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> ProgTurn => _progTurn;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>�^�[����i�߂�A����{�^���ɃA�^�b�`���Ďg��</summary>
    public void AddTurn() => _progTurn.Value++;
}
