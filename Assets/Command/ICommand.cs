using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コマンドをオブジェクトとしてラップしておくインターフェース
/// </summary>
public interface ICommand
{
    public void Execute();
    public void Undo();
}
