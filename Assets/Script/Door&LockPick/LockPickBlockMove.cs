using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockPickBlockMove : MonoBehaviour
{
    public float Undrag = 0.01f;
    public float maxy;
    public float miny = -2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localP = this.transform.localPosition;
        if(localP.y < miny)
        {
            localP.y = miny;
            this.transform.localPosition = localP;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pin")
        {
            Rigidbody rigid = other.GetComponent<Rigidbody>();
            float force = Vector3.Dot(rigid.velocity, this.transform.up);
            if (force < 0)
            {
                this.transform.position += this.transform.up * force * Undrag;
            }
        }
    }

}
