using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followplayer : MonoBehaviour
{
    public Transform player;  // 플레이어의 위치를 참조할 변수
    private NavMeshAgent agent;  // NavMeshAgent를 저장할 변수

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent 컴포넌트를 가져옴
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);  // 플레이어의 위치로 목적지를 설정
        }
    }
}
