using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// �o�߃^�[���̕\�����s��Presenter
/// </summary>
public class TurnPresenter : MonoBehaviour
{
    [SerializeField] TurnView _view;
    [SerializeField] GameManager _model;

    void Start()
    {
        _model.ProgTurn.Subscribe(i => _view.Set(i.ToString())).AddTo(this);
    }

    void Update()
    {
        
    }
}
