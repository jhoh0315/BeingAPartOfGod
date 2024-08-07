using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zega1 : MonoBehaviour
{
        public List<Transform> wayPoint;

    NavMeshAgent navMeshAgent;

    public int currentWayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
    }

    void Walking()
    {
        if (wayPoint.Count == 0)
        {
            Debug.LogWarning("No waypoints assigned.");
            return;
        }

        float distanceToWayPoint = Vector3.Distance(wayPoint[currentWayPointIndex].position, transform.position);

        if (distanceToWayPoint <= 3)
        {
            currentWayPointIndex = (currentWayPointIndex + 1) % wayPoint.Count;
        }

        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(wayPoint[currentWayPointIndex].position);
        }
        else
        {
            Debug.LogError("NavMeshAgent component is missing on this GameObject.");
        }
    }
}
