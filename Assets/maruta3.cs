using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maruta3 : MonoBehaviour
{
    public Animator animator;       // Animator 컴포넌트
    public float moveDistance = 5f; // 이동할 거리
    public float moveDuration = 2f; // 이동하는데 걸리는 시간
    public AudioSource source;

    private bool isWalking = false; // 캐릭터가 걷는 중인지 확인하는 변수

    bool isdo = false;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player" && !isdo)
        {
            isdo = true;
            source.Play();
            animator.SetTrigger("maruta3");
        }
    }
    void Update()
    {
        // "Walk" 애니메이션이 실행 중인지 확인
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("crawl") && !isWalking)
        {
            isWalking = true;
            StartCoroutine(MoveForward());
        }

        // "Walk" 애니메이션이 끝나면 이동을 멈추도록 설정
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("crawl") && isWalking)
        {
            isWalking = false;
        }
    }

    IEnumerator MoveForward()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + transform.forward * moveDistance;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // 정확히 목표 위치에 도달
    }
}
