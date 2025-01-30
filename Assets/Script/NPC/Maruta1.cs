using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maruta1 : MonoBehaviour
{
    public Animator animator;
    public AudioSource source1;
    public AudioSource source2;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            if (Random.Range(0, 2) == 1)
            {
                animator.SetTrigger("caugh");
                source2.Play();
            }
            else
            {
                animator.SetTrigger("seizure");
                source1.Play();
            }
        }
    }
}
