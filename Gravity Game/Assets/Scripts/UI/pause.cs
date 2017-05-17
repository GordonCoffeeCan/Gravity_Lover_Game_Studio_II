using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour {

    bool paused = false;

    public Image quitButton;
    

    void Start()
    {
        quitButton.gameObject.SetActive(false);
        //Debug.Log("Pause");
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            paused = togglePause();

            quitButton.gameObject.SetActive(true);

            NewGameData.paused = true;

            //Debug.Log(NewGameData.paused);
        }

        if (paused == false)
        {
            quitButton.gameObject.SetActive(false);

            NewGameData.paused = false;
           // Debug.Log(NewGameData.paused);
        } 
   
        Debug.Log(NewGameData.paused);
    }

    void OnGUI()
    {
        if (paused)
        {
            

            quitButton.enabled = true;
          

            if (Input.GetButtonDown("Fire1"))
            {
                paused = togglePause();
            }

            
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
