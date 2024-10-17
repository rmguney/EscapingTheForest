using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool hasKey = false;
    private bool doorOpened = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PickUpKey()
    {
        hasKey = true;
    }

    public void OpenDoor()
    {
        if (hasKey && !doorOpened)
        {
            doorOpened = true;
            SceneManager.LoadScene(1);
        }
    }
}