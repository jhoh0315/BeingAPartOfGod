using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    public static GameManager instance;
    public float TurnSpeed = 50;
    public float Bright;
    public int nowSceneNum;
    [SerializeField]public string[] SceneName;
    public GameObject WarningUI;


    private GameObject CameraOffset;
    public bool settingdone = true;
    public float CameraYOffset = 1.6f;

    private bool isTriggeron;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { 
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CameraOffset = GameObject.Find("Camera Offset");
        settingdone = scene.name == "starting room";
        Debug.Log("Loaded scene " + scene.name);
    }

    private void Update()
    {
        if (!settingdone)
        {
            CameraOffset.transform.localPosition = new Vector3(0, CameraYOffset, 0);
        }

        if (inputActionAsset.actionMaps[5].actions[4].IsPressed())
        {
            if (!isTriggeron)
            {
                isTriggeron = true;
                nowSceneNum += 1;
                if (nowSceneNum == SceneName.Length) { nowSceneNum = 0; }
                SceneManager.LoadScene(SceneName[nowSceneNum]);
            }
        }
        else
        {
            isTriggeron = false;
        }

        if (inputActionAsset.actionMaps[0].actions[2].IsPressed())
        {
            WarningUI.SetActive(false);
        }
        else
        {
            WarningUI.SetActive(true);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
