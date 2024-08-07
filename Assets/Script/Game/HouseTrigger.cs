using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] questitem;
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public float waittime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (VillageManager.instance.questClearCheck() && VillageManager.instance.nowStep == 0)
            {
                VillageManager.instance.nowStep = 1;
                for (int i = 0;i < questitem.Length;i++)
                {
                    questitem[i].gameObject.SetActive(false);
                }
                StartCoroutine(playSound());
                VillageManager.instance.GuideChange(1);

            }
        }
    }
    private IEnumerator playSound()
    {
        AudioSource1.Play();
        yield return new WaitForSeconds(waittime);
        AudioSource2.Play();
    }
}
