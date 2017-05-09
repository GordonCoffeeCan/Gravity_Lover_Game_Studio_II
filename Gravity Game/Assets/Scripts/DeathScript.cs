using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {

    private string currentScene;

    public float deathDelay = 1.0f;
    private GameObject player1;
    private GameObject player2;

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
			MixerScript myMixerScript  = GameObject.Find ("MusicSource").GetComponent<MixerScript> ();

			//myMixerScript.blackFade = true;
            Invoke("Restart", deathDelay);

            player1 = GameObject.FindWithTag("Player1").gameObject;
            player2 = GameObject.FindWithTag("Player2").gameObject;

            player1.SetActive(false);
            player2.SetActive(false);


        }
            

    }

    void Restart() {
        SceneManager.LoadScene(currentScene);
    }

}
