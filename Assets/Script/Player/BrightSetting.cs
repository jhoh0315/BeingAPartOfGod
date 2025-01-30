using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BrightSetting : MonoBehaviour
{
    public float maxx = 1;
    public float minx = -1;
    public Transform SetValue;
    public float MaxValue = 2;
    public bool doUpdate = false;
    public Transform centerTransform;
    public Volume volume;

    private LiftGammaGain LiftGammaGain;

    private void Start()
    {
        volume.profile.TryGet<LiftGammaGain>(out LiftGammaGain);
        BrightnessSetup();
    }

    private void Update()
    {
        if (doUpdate)
        {
            Updateing();
        }
        
    }

    public void SetValueBack()
    {
        SetValue.transform.position = this.transform.position;
    }

    public void BrightnessSetup()
    {
        Vector3 tmp = transform.position - centerTransform.position;
        tmp.x = (LiftGammaGain.gamma.value.w + 1) * (maxx - minx) / MaxValue + minx;
        tmp += centerTransform.position;
        transform.position = tmp;
        SetValueBack();
    }

    private void Updateing()
    {
        Vector3 target = transform.position - centerTransform.position;
        target.x = SetValue.position.x - centerTransform.position.x;
        if (target.x > maxx) target.x = maxx;
        if (target.x < minx) target.x = minx;
        this.transform.position = target + centerTransform.position;

        LiftGammaGain.gamma.value = new Vector4(1,1,1,MaxValue * (target.x - minx) / (maxx - minx) - 1);
    }

    public void doupdating(bool tmp)
    {
        doUpdate = tmp;
    }
}
