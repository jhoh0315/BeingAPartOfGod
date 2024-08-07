using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject[] settings;

    private void Awake()
    {
        GameSettingOut();
    }

    public void GameStarting()
    {
        SceneManager.LoadScene("Village");
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
