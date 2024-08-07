using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JobFind : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public int jobnum;
    public Collider[] wall;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource1.outputAudioMixerGroup = AudioMixer.FindMatchingGroups(SoundType.EFFECT.ToString())[0];
        AudioSource1.spatialBlend = 1.0f;
        AudioSource1.rolloffMode = AudioRolloffMode.Linear;
        AudioSource1.minDistance = 0;
        AudioSource1.maxDistance = 50;
        AudioSource2.outputAudioMixerGroup = AudioMixer.FindMatchingGroups(SoundType.EFFECT.ToString())[0];
        AudioSource2.spatialBlend = 1.0f;
        AudioSource2.rolloffMode = AudioRolloffMode.Linear;
        AudioSource2.minDistance = 0;
        AudioSource2.maxDistance = 50;
        for (int i = 0; i < wall.Length; i++)
        {
            wall[i].enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && VillageManager.instance.nowStep == jobnum)
        {
            VillageManager.instance.nowStep = jobnum + 1;
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i].enabled = true;
            }
            StartCoroutine(playSound());
        }
    }

    private IEnumerator playSound()
    {
        AudioSource1.Play();
        AudioSource2.Play();
        yield return new WaitForSeconds(AudioSource1.clip.length>AudioSource2.clip.length?AudioSource1.clip.length:AudioSource2.clip.length);
        for (int i = 0; i < wall.Length; i++)
        {
            wall[i].enabled = false;
        }
    }


}

