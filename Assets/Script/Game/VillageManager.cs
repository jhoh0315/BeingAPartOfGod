using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    public static VillageManager instance;
    public int nowStep = 0;
    public GameObject Guide;
    [SerializeField] public Material[] GuideMaterial;
    [SerializeField] public bool[] questCheck;
    // Start is called before the first frame update
    private void Awake()
    {
        GuideChange(0);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public bool questClearCheck()
    {
        for (int i = 0; i < questCheck.Length; i++)
        {
            if (questCheck[i] == false)
            {
                return (false);
            }
        }
        return (true);
    }

    public void GuideChange(int n)
    {
        MeshRenderer mesh = Guide.GetComponent<MeshRenderer>();
        mesh.material = GuideMaterial[n];
    }
}
