using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NPCAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups(SoundType.EFFECT.ToString())[0];
        AudioSource.spatialBlend = 1.0f;
        AudioSource.rolloffMode = AudioRolloffMode.Linear;
        AudioSource.minDistance = 0;
        AudioSource.maxDistance = 5;

        StartCoroutine(playSound());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private IEnumerator playSound()
    {
        AudioSource.Play();
        yield return new WaitForSeconds(Random.Range(5.0f, 8.0f));
        yield return new WaitForSeconds(AudioSource.clip.length);
        StartCoroutine(playSound());
    }
}
