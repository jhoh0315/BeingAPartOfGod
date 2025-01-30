using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(sound());
        }
    }

    private IEnumerator sound()
    {
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        GameManager.instance.GameOver();
    }
}
