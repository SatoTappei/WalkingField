using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 経過ターンの表示を行うPresenter
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
