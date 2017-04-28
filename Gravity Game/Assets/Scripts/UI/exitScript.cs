using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScript : MonoBehaviour {

    private string currentScene;

    // Use this for initialization
    public void quitGame()
    {
        currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);

    }

    public void changeToScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
