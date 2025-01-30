using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;

public class FailTrigger : MonoBehaviour
{
    public Animation DoorClose;
    public Animator Doctor1;
    public Animator Doctor2;
    public float waittime;
    private void OnTriggerEnter(Collider other)
    {
        DoorClose.Play();
        Doctor1.SetTrigger("seeplayer");
        Doctor2.SetTrigger("seeplayer"); 
        StartCoroutine(gameover());
    }
    private IEnumerator gameover()
    {
        yield return new WaitForSeconds(waittime);
        GameManager.instance.GameOver();
    }


}
