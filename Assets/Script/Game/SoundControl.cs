using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Audio;

public class SoundControl : MonoBehaviour
{
    public float maxx = 0;
    public float minx = 0;
    public Transform SetValue;
    public SoundType SoundType;
    public float SoundValue;
    public float MaxValue = 1;
    public bool doUpdate = false;
    public Transform centerTransform;

    private void Start()
    {
        SoundValueSetUp();
    }

    private void Update()
    {
        if (doUpdate)
        {
            Updating();
        }
    }

    public void SetValueBack()
    {
        SetValue.transform.position = this.transform.position;
    }

    public void SoundValueSetUp()
    {
        Vector3 tmp = transform.position - centerTransform.position;
        tmp.x = SoundValue * (maxx - minx) / MaxValue + minx;
        transform.position = tmp + centerTransform.position;
        SetValueBack();
    }

    private void Updating()
    {
        Vector3 target = transform.position - centerTransform.position;
        target.x = SetValue.position.x - centerTransform.position.x;
        if (target.x > maxx) target.x = maxx;
        if (target.x < minx) target.x = minx;
        this.transform.position = target + centerTransform.position;

        SoundValue = MaxValue * (target.x - minx) / (maxx - minx);
        SoundManager.instance.SetVolume(SoundType, SoundValue);
    }

    public void doupdating(bool tmp)
    {
        doUpdate = tmp;
    }
}
