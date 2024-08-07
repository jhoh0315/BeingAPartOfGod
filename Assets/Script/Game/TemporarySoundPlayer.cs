using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class TemporarySoundPlayer : MonoBehaviour
{
    private AudioSource mAudioSource;
    public string ClipName
    {
        get
        {
            return mAudioSource.clip.name;
        }
    }

    public void Awake()
    {
        this.AddComponent<AudioSource>();
        mAudioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioMixerGroup audioMixer, float delay, bool isLoop)
    {
        mAudioSource.outputAudioMixerGroup = audioMixer;
        mAudioSource.loop = isLoop;
        mAudioSource.Play();

        if (!isLoop) { StartCoroutine(COR_DestroyWhenFinish(mAudioSource.clip.length)); }
    }

    public void InitSound2D(AudioClip clip)
    {
        mAudioSource.clip = clip;
    }

    public void InitSound3D(AudioClip clip, float minDistance, float maxDistance)
    {
        mAudioSource.clip = clip;
        mAudioSource.spatialBlend = 1.0f;
        mAudioSource.rolloffMode = AudioRolloffMode.Linear;
        mAudioSource.minDistance = minDistance;
        mAudioSource.maxDistance = maxDistance;
    }

    private IEnumerator COR_DestroyWhenFinish(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);

        Destroy(gameObject);
    }
}
