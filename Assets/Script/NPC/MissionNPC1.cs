using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionNPC1 : MonoBehaviour
{
    public float speed;
    public float range;
    float startposX;
    private void Awake()
    {
        startposX = transform.position.x;
        StartCoroutine(move());
    }

    private IEnumerator move()
    {
        Vector3 pos = transform.position;
        pos.x += speed;
        transform.position = pos;
        yield return new WaitForSeconds(0.01f);
        if (startposX + range > transform.position.x)
        {
            StartCoroutine(move());
        }
        
    }
}
