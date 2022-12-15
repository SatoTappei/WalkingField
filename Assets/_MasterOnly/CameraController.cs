using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを追従するカメラ
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target;

    void Start()
    {

    }

    void LateUpdate()
    {
        if (_target == null) return;

        Vector3 start = transform.position;
        Vector3 end = _target.transform.position;
        end.z = start.z;
        float t = Time.deltaTime * 4.0f;
        transform.position = Vector3.Lerp(start, end, t);
    }
}
