using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {

    private string currentScene;

	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene().name;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
       if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            SceneManager.LoadScene(currentScene);
        }
            

    }

}
