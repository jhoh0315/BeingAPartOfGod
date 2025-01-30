using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorOpen : MonoBehaviour
{
    public GameObject key;
    public Door door;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "key") {
            other.gameObject.SetActive(false);
            key.SetActive(true);
            Animator animator = GetComponent<Animator>();
            animator.enabled = true;
            door.isopen = true;
            source.Play();
        }
    }
}
