using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour {

    bool paused = false;

    public Button quitButton;
    

    void Start()
    {
        quitButton.gameObject.SetActive(false);
        //Debug.Log("Pause");
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused = togglePause();

            quitButton.gameObject.SetActive(true);

        }

        if (paused == false)
        {
            quitButton.gameObject.SetActive(false);
        }
       
    }

    void OnGUI()
    {
        if (paused)
        {
            quitButton.enabled = true;
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpause"))
                paused = togglePause();
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
            
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
            
        }
    }
}
