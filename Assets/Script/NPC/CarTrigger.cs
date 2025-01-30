using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTrigger : MonoBehaviour
{
    public AudioSource source;
    public GameObject carstart;
    public AudioClip AudioClip;
    public string NextSceneName;

    bool isDo = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isDo) {
            source.Play();
            carstart.SetActive(true);
            isDo = true;
        }
    }

    public void StartNextScene()
    {
        StartCoroutine(nextScene());
    }

    public IEnumerator nextScene()
    {
        yield return new WaitForSeconds(AudioClip.length);
        SceneManager.LoadScene(NextSceneName);
    }

}
