using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameManager : MonoBehaviour
{
    // 経過ターン、決定ボタンが押されるたびに+1される
    ReactiveProperty<int> _progTurn = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> ProgTurn => _progTurn;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>ターンを進める、決定ボタンにアタッチして使う</summary>
    public void AddTurn() => _progTurn.Value++;
}
