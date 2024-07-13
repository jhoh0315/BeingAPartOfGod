using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool a = true;

    // Update is called once per frame
    void Update()
    {
//        if (a){TestCode();a = false;}
    }
    public void TestCode()
    {
        SoundManager.instance.PlaySound2D("Test");
    }
}
