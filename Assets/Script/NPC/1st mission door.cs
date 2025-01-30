using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sc : MonoBehaviour
{
    // 회전 속도를 조절할 수 있는 변수
    public float rotationSpeed = 90f; // 90 degrees per second

    // 충돌 이벤트 핸들러

    void OnTriggerEnter(Collider collider){
        StartCoroutine(RotateCounterClockwise());
    }

    // 시계 반대 방향으로 회전시키는 코루틴
    IEnumerator RotateCounterClockwise()
    {
        Debug.Log("aaa");
        float rotationAmount = 0f;
        float targetRotation = 45f; // 목표 회전 각도

        // 목표 각도에 도달할 때까지 회전
        while (rotationAmount < targetRotation)
        {
            float rotateStep = rotationSpeed * Time.deltaTime;
            
            // 남은 회전 각도보다 한 프레임에서 회전할 각도가 더 크다면, 남은 각도만큼만 회전
            if (rotationAmount + rotateStep > targetRotation)
            {
                rotateStep = targetRotation - rotationAmount;
            }
            
            transform.Rotate(0, -rotateStep, 0); // y축을 기준으로 시계 반대 방향 회전
            rotationAmount += rotateStep;
            yield return null;
        }
    }
}
