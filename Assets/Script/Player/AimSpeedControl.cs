using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSpeedControl : MonoBehaviour
{
    public float maxx = 1;
    public float minx = -1;
    public Transform SetValue;
    public float MaxValue = 100;
    public bool doUpdate = false;
    public Transform centerTransform;

    private void Start()
    {
        AimSpeedSetup();
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

    public void AimSpeedSetup()
    {
        Vector3 tmp = transform.position - centerTransform.position;
        tmp.x = GameManager.instance.TurnSpeed * (maxx - minx) / MaxValue + minx;
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

        GameManager.instance.TurnSpeed = MaxValue * (target.x - minx) / (maxx - minx);
    }

    public void doupdating(bool tmp)
    {
        doUpdate = tmp;
    }
}
