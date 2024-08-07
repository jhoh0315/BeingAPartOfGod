using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour
{
    public Animator animator;  // 애니메이터 컴포넌트
    public float speed = 2.0f; // 이동 속도
    public float rotationSpeed = 180.0f; // 회전 속도 (초당 180도)
    public float turnThreshold = 0.90f; // 애니메이션 진행도 임계값 (예: 90%)

    private bool hasTurned = false; // 캐릭터가 회전했는지 여부를 확인하는 플래그

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // "Walking1" 또는 "Walking2" 애니메이션이 재생 중인지 확인
        if ((stateInfo.IsName("Walking1")) || (stateInfo.IsName("Walking2")))
        {
            Debug.Log("moving");
            // 캐릭터를 앞으로 이동
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        // "turn" 애니메이션이 재생 중인지 확인
        else if (stateInfo.IsName("turn"))
        {
            Debug.Log("turning");

            // 캐릭터가 회전했는지 여부를 확인
            if (!hasTurned)
            {
                StartCoroutine(Rotate180Degrees());
                hasTurned = true;
            }
        }
        else
        {
            // "turn" 애니메이션이 끝나면 회전 플래그 재설정
            hasTurned = false;
        }
    }

    IEnumerator Rotate180Degrees()
    {
        float targetAngle = transform.eulerAngles.y - 180.0f;
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.1f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
            yield return null;
        }

        // Ensure the rotation is exactly 180 degrees
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetAngle, transform.eulerAngles.z);
    }
}
