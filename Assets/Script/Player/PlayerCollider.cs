using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public Transform High;
    public Transform player;
   

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.position.x,High.position.y,player.position.z);
    }
}
