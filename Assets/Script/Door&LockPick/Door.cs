using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform Handle;
    public Transform TargetTransform;
    public float maxRotation;
    public float minRotation;
    public bool isopen = false;

    private void FixedUpdate()
    {
        if (isopen) DoorTurn();
    }

    void DoorTurn()
    {
        Vector3 vector = TargetTransform.position - transform.position;
        vector = new Vector3(vector.x, 0, vector.z);
        Quaternion rotation = Quaternion.LookRotation(vector).normalized;
        if (rotation.y > maxRotation)
        {
            rotation.y = maxRotation;
        }
        if (rotation.y < minRotation)
        {
            rotation.y = minRotation;
        }
        transform.rotation = rotation;
    }
    public void positionBack()
    {
        TargetTransform.transform.position = Handle.transform.position;
    }

    public void SetIsOpen(bool tmp)
    {
        isopen = tmp;
    }
}
