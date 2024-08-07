using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockPickClearCheck : MonoBehaviour
{
    public bool isClearing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        isClearing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isClearing = false;
    }
}
