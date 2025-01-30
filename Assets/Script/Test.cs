using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{

    public float speed;
    private void Start()
    {
        Screen.brightness = 0;
    }
    private void Update()
    {
        Screen.brightness = speed;
        Debug.Log(Screen.brightness);
    }
}
