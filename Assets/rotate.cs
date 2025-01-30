using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // 회전 속도

    void Update()
    {
        // Y축을 기준으로 오브젝트 회전
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
