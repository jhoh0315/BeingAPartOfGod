using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
    }

    private void OnEnable()
    {
        this.transform.position = tf.position;
        this.transform.rotation = tf.rotation;
    }
}
