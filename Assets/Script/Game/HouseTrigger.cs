using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] questitem;
    public string Scenename;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (VillageManager.instance.questClearCheck() && VillageManager.instance.nowStep == 0)
            {
                SceneManager.LoadScene(Scenename);
            }
        }
    }
}
