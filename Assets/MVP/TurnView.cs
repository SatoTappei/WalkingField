using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 経過ターンを表示するView
/// </summary>
public class TurnView : MonoBehaviour
{
    [SerializeField] Text _text;

    void Awake()
    {
        _text.text = "0";
    }

    public void Set(string str)
    {
        _text.text = str;
        // ここにDotWeenのアニメーションなどを書く
    }
}
