using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HurryUpTrigger : MonoBehaviour
{
    public rotate ro;
    private void OnTriggerEnter(Collider other)
    {
        if (ro.rotationSpeed!=1000) 
        {
            ro.rotationSpeed = 1000;
        }
    }


}
