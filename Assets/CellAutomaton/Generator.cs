using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject _land;
    [SerializeField] GameObject _sea;

    [SerializeField] int _width;
    [SerializeField] int _height;
    [SerializeField] int _offsetX;
    [SerializeField] int _offsetY;
    [SerializeField] float _cellSize = 0.64f;

    IEnumerator Start()
    {
        int[,] map = Init(_height, _width);

        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            int[,] temp = new int[_height, _width];
            // セル1つ1つに対して確認処理
            // 画面端の4辺は海にしたいので処理を行わない <= 現状完全ランダムなので海にするよう直す
            for (int y = 1; y < _height - 1; y++)
                for (int x = 1; x < _width - 1; x++)
                {      
                    // 周囲8マス
                    int lux = x - 1;
                    int luy = y - 1;
                    int rbx = x + 1;
                    int rby = y + 1;

                    // 現在のマスとは別のマスが周囲に何個あるか
                    int count = 0;
                    for (int cy = luy; cy <= rby; cy++)
                        for (int cx = lux; cx <= rbx; cx++)
                        {
                            if (map[cy, cx] == 1 - map[y, x])
                            {
                                count++;
                            }
                        }

                    // 4つ以上あれば次はそのマスになる
                    temp[y, x] = count >= 5 ? 1 - map[y, x] : map[y, x];
                }

            // 一時保存しておいたマップデータを次の世代として複製する
            map = temp;
            // 次の世代を生成
            Next(map);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
        } 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>ランダムに陸か海を生成して対応する二次元配列を返す</summary>
    int[,] Init(int h, int w)
    {
        int[,] array = new int[h,w];

        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
            {
                array[y, x] = Random.Range(0, 2);
                GameObject go = array[y, x] == 0 ? _sea : _land;

                float px = x * _cellSize + _offsetX;
                float py = y * _cellSize + _offsetY;
                
                // 処理負荷的にここで生成してしまうのが良い
                Instantiate(go, new Vector3(px, py, 0), Quaternion.identity, transform);
            }

        return array;
    }

    /// <summary>次の世代のセルを生成する</summary>
   void Next(int[,] next)
    {
        // 子を全削除
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // 次の世代を生成する
        for (int y = 0; y < next.GetLength(0); y++)
            for (int x = 0; x < next.GetLength(1); x++)
            {
                GameObject go = next[y, x] == 0 ? _sea : _land;

                float px = x * _cellSize + _offsetX;
                float py = y * _cellSize + _offsetY;

                // 処理負荷的にここで生成してしまうのが良い
                Instantiate(go, new Vector3(px, py, 0), Quaternion.identity, transform);
            }

        //
    }
}
