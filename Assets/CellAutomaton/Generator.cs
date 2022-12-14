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

    void Start()
    {
        int[,] map = Init(_height, _width);

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>�����_���ɗ����C�𐶐����đΉ�����񎟌��z���Ԃ�</summary>
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
                
                // �������דI�ɂ����Ő������Ă��܂��̂��ǂ�
                Instantiate(go, new Vector3(px, py, 0), Quaternion.identity, transform);
            }

        return array;
    }
}
