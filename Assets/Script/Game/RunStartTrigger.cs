using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStartTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] Runners;


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("aaa");
            for (int i = 0; i < Runners.Length; i++)
            {
                Runners[i].SetActive(true);
            }
        }
    }

}
