using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class JailStory : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] public AudioSource[] source;
    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < source.Length;i++)
        {
            source[i].outputAudioMixerGroup = AudioMixer.FindMatchingGroups(SoundType.EFFECT.ToString())[0];
            source[i].spatialBlend = 1.0f;
            source[i].rolloffMode = AudioRolloffMode.Linear;
            source[i].minDistance = 0;
            source[i].maxDistance = 50;
        }
        StartCoroutine(Storygogo());
    }
    private IEnumerator Storygogo()
    {
        for (int i = 0; i < source.Length; i++)
        {
            source[i].Play();
            yield return new WaitForSeconds(source[i].clip.length);
        }
        SceneManager.LoadScene(nextSceneName);

    }
}
