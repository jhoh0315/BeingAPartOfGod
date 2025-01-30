using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maruta2 : MonoBehaviour
{
    public Animator animator;
    public AudioSource source;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            source.Play ();
            animator.SetTrigger("zombie stand");
        }
    }
}
