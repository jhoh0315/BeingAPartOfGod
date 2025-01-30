using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject[] settings;
    public GameObject UI;
    public float TargetYOffset;
    public InputActionAsset inputActionAsset;
    public GameObject CameraOffset;
    public GameObject MainCamera;


    private void Awake()
    {
        GameSettingOut();
        UI.SetActive(true);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (inputActionAsset.actionMaps[4].actions[13].IsPressed())
        {
            UI.SetActive(false);
            Vector3 pos = CameraOffset.transform.position;
            pos.y += TargetYOffset - MainCamera.transform.position.y;
            CameraOffset.transform.position = pos;
            GameManager.instance.CameraYOffset = CameraOffset.transform.localPosition.y;
        }
    }

    public void GameStarting()
    {
        GameManager.instance.nowSceneNum = 1;
        SceneManager.LoadScene("Village1");
    }

    public void GameSettingIn()
    {
        foreach (GameObject Object in settings)
        {
            Object.SetActive(true);
        }
    }
    public void GameSettingOut()
    {
        foreach (GameObject Object in settings)
        {
            Object.SetActive(false);
        }
    }
}
