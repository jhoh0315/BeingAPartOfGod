using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    private void Start()
    {
        transform.localPosition = new Vector3(0, GameManager.instance.CameraYOffset, 0);

    }
}
