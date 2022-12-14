using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// MVPパターンでUIを実装するためにテスト用の値を保持する
/// 最終的にMergeするときは値を良い感じに移す
/// </summary>
public class MVPTest : MonoBehaviour
{
    // 経過ターン、決定ボタンが押されるたびに+1される予定
    ReactiveProperty<int> _progTurn = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> ProgTurn => _progTurn;

    void Start()
    {
        
    }

    void Update()
    {
        // テスト、キーが押されたら経過ターンを増やす
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _progTurn.Value++;
            Debug.Log("次のターンへ");
        }
    }
}
