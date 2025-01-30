using Oculus.Interaction.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using static Unity.VisualScripting.Member;

public class VillageStoryManeger : MonoBehaviour
{
    public string scenename;
    public VideoClip clip;
    void Start()
    {
        StartCoroutine(play());
    }

    private IEnumerator play()
    {
        yield return new WaitForSeconds(((float)clip.length));
        SceneManager.LoadScene(scenename);
    }
}
