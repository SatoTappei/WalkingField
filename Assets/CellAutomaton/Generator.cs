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
            // �Z��1��1�ɑ΂��Ċm�F����
            // ��ʒ[��4�ӂ͊C�ɂ������̂ŏ������s��Ȃ� <= ���󊮑S�����_���Ȃ̂ŊC�ɂ���悤����
            for (int y = 1; y < _height - 1; y++)
                for (int x = 1; x < _width - 1; x++)
                {      
                    // ����8�}�X
                    int lux = x - 1;
                    int luy = y - 1;
                    int rbx = x + 1;
                    int rby = y + 1;

                    // ���݂̃}�X�Ƃ͕ʂ̃}�X�����͂ɉ����邩
                    int count = 0;
                    for (int cy = luy; cy <= rby; cy++)
                        for (int cx = lux; cx <= rbx; cx++)
                        {
                            if (map[cy, cx] == 1 - map[y, x])
                            {
                                count++;
                            }
                        }

                    // 4�ȏ゠��Ύ��͂��̃}�X�ɂȂ�
                    temp[y, x] = count >= 5 ? 1 - map[y, x] : map[y, x];
                }

            // �ꎞ�ۑ����Ă������}�b�v�f�[�^�����̐���Ƃ��ĕ�������
            map = temp;
            // ���̐���𐶐�
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

    /// <summary>���̐���̃Z���𐶐�����</summary>
   void Next(int[,] next)
    {
        // �q��S�폜
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // ���̐���𐶐�����
        for (int y = 0; y < next.GetLength(0); y++)
            for (int x = 0; x < next.GetLength(1); x++)
            {
                GameObject go = next[y, x] == 0 ? _sea : _land;

                float px = x * _cellSize + _offsetX;
                float py = y * _cellSize + _offsetY;

                // �������דI�ɂ����Ő������Ă��܂��̂��ǂ�
                Instantiate(go, new Vector3(px, py, 0), Quaternion.identity, transform);
            }

        //
    }
}
