using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundType
{
    BGM,
    EFFECT,
}

public class SoundManager : MonoBehaviour
{   
    [SerializeField] private AudioMixer mAudioMixer;

    private float mCurrentBGMVolume, mCurrentEffectVolume;

    private Dictionary<string, AudioClip> mClipsDictionary;

    [SerializeField] private AudioClip[] mPreloadClips;

    private List<TemporarySoundPlayer> mInstantiatedSounds;
    public static SoundManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        mClipsDictionary = new Dictionary<string, AudioClip>();
        foreach (AudioClip clip in mPreloadClips)
        {
            mClipsDictionary.Add(clip.name, clip);
        }
        mInstantiatedSounds = new List<TemporarySoundPlayer>();
    }

    private AudioClip GetClip(string clipName)
    {
        AudioClip clip = mClipsDictionary[clipName];
        if (clip == null) { Debug.LogError(clipName + "이 존재하지 않습니다."); }
        
        return clip;
    }

    private void AddToList(TemporarySoundPlayer soundPlayer)
    {
        mInstantiatedSounds.Add(soundPlayer);
    }

    public void StopLoopSound(string clipName)
    {
        foreach (TemporarySoundPlayer audioPlayer in mInstantiatedSounds)
        {
            if (audioPlayer.ClipName == clipName)
            {
                mInstantiatedSounds.Remove(audioPlayer);
                Destroy(audioPlayer.gameObject);
                return;
            }
        }

        Debug.LogWarning(clipName + "을 찾을 수 없습니다.");
    }

    public void PlaySound2D(string clipName, float delay = 0f, bool isLoop = false, SoundType type = SoundType.EFFECT)
    {
        GameObject obj = new GameObject("TemporarySoundPlayer 2D");
        TemporarySoundPlayer soundPlayer = obj.AddComponent<TemporarySoundPlayer>();

        if (isLoop) { AddToList(soundPlayer); }

        soundPlayer.InitSound2D(GetClip(clipName));
        soundPlayer.Play(mAudioMixer.FindMatchingGroups(type.ToString())[0], delay, isLoop);
    }

    public void PlaySound3D(string clipName, Transform audioTarget, float delay = 0f, bool isLoop = false, SoundType type = SoundType.EFFECT, bool attachToTarget = true, float minDistance = 0.0f, float maxDistance = 50.0f)
    {
        GameObject obj = new GameObject("TemporarySoundPlayer 3D");
        obj.transform.localPosition = audioTarget.transform.position;
        if (attachToTarget) { obj.transform.parent = audioTarget; }

        TemporarySoundPlayer soundPlayer = obj.AddComponent<TemporarySoundPlayer>();

        if (isLoop) { AddToList(soundPlayer); }

        soundPlayer.InitSound3D(GetClip(clipName), minDistance, maxDistance);
        soundPlayer.Play(mAudioMixer.FindMatchingGroups(type.ToString())[0], delay, isLoop);
    }

    public void InitVolumes(float bgm, float effect)
    {
        SetVolume(SoundType.BGM, bgm);
        SetVolume(SoundType.EFFECT, effect);
    }

    public void SetVolume(SoundType type, float value)
    {
        mAudioMixer.SetFloat(type.ToString(), value);
    }

    public static string Range(int from, int includedTo, bool isStartZero = false)
    {
        if (includedTo > 100 && isStartZero) { Debug.LogWarning("0을 포함한 세자리는 지원하지 않습니다."); }

        int value = UnityEngine.Random.Range(from, includedTo + 1);

        return value < 10 && isStartZero ? '0' + value.ToString() : value.ToString();
    }

}
