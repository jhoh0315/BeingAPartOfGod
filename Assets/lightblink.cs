using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightblink : MonoBehaviour
{// Light component를 참조하기 위한 변수
    private Light pointLight;

    // 깜빡거리는 간격 (최소, 최대 시간 간격)
    public float minFlickerTime = 0.05f;
    public float maxFlickerTime = 0.2f;

    void Start()
    {
        // 이 오브젝트에 있는 Light 컴포넌트를 가져옴
        pointLight = GetComponent<Light>();

        // 깜빡거림 시작
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // 랜덤으로 깜빡거리는 시간을 설정
            float flickerTime = Random.Range(minFlickerTime, maxFlickerTime);
            yield return new WaitForSeconds(flickerTime);

            // Light의 활성화/비활성화 상태를 반전
            pointLight.enabled = !pointLight.enabled;
        }
    }
}
