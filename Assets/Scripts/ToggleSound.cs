using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSound : MonoBehaviour
{
    private AudioListener audioListener;

    void Start()
    {
       audioListener = Camera.main.GetComponent<AudioListener>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioListener != null)
            {
                audioListener.enabled = !audioListener.enabled;
            }
        }
    }
}
