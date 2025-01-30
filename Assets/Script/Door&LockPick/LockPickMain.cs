using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickMain : MonoBehaviour
{
    public Transform LockPickLook;
    public Transform Handle;
    public Door door;
    public LockPickClearCheck block1;
    public LockPickClearCheck block2;
    public LockPickClearCheck block3;
    public LockPickClearCheck block4;
    public LockPickBlockMove box1;
    public LockPickBlockMove box2;
    public LockPickBlockMove box3;
    public LockPickBlockMove box4;

    public GameObject MainObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //        LockPickturn();
        transform.LookAt(LockPickLook);
        if (LockPickClearCheck())
        {
            door.isopen = true;
            MainObject.SetActive(false);
        }

    }

    void LockPickturn()
    {
        Vector3 vector = LockPickLook.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(vector).normalized;
        transform.rotation = rotation;
    }

    public void LockPickBack()
    {
        LockPickLook.transform.position = Handle.transform.position;
    }

    public bool LockPickClearCheck()
    {
        return (block1.isClearing && block2.isClearing && block3.isClearing && block4.isClearing);
    }

    public void LockPickReset()
    {
        box1.transform.localPosition = new Vector3(box1.transform.localPosition.x, box1.maxy, box1.transform.localPosition.z);
        box2.transform.localPosition = new Vector3(box2.transform.localPosition.x, box2.maxy, box2.transform.localPosition.z);
        box3.transform.localPosition = new Vector3(box3.transform.localPosition.x, box3.maxy, box3.transform.localPosition.z);
        box4.transform.localPosition = new Vector3(box4.transform.localPosition.x, box4.maxy, box4.transform.localPosition.z);
    }

}
