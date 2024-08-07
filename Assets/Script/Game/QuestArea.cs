using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestArea : MonoBehaviour
{
    public int questLevel;
    
    private void OnTriggerEnter(Collider other)
    {
        QuestObject qo = other.GetComponent<QuestObject>();
        if (qo.questLevel == questLevel)
        {
            VillageManager.instance.questCheck[questLevel] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        QuestObject qo = other.GetComponent<QuestObject>();
        if (qo.questLevel == questLevel)
        {
            VillageManager.instance.questCheck[questLevel] = false;
        }
    }
}