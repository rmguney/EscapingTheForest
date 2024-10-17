using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string mainGameSceneName = "Game";
    public KeyCode restartKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(restartKey))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(mainGameSceneName);
    }
}
