using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionScript : MonoBehaviour {

	public bool player1Trigger = false;

	public bool player2Trigger = false;

    private bool isSceneLoaded = false;

	private string sceneToLoad;

    public Object sceneToLoad2;
  


    //For Resetting scene
    private Vector3 pos1;
    private Vector3 pos2;

    public string player1SaveString;
    public string player2SaveString;

    public GameObject player1SpawnPoint;
    public GameObject player2SpawnPoint;



    private void Awake() {
        isSceneLoaded = false;
    }

    void Update (){
		if (player1Trigger == true && player2Trigger == true) {
			MixerScript myMixerScript  = GameObject.Find ("MusicSource").GetComponent<MixerScript> ();

			//myMixerScript.blackFade = true;

            if(isSceneLoaded == false) {

                if(SceneManager.GetActiveScene().name== "tutorialScene")
                {
                    NewGameData.tutorialLevelDone = true;
                }

                if (SceneManager.GetActiveScene().name == "SpokeOnePrototype")
                {
                    NewGameData.level02Done = true;
                }

                if (SceneManager.GetActiveScene().name == "SpokeTwoPrototype")
                {
                    NewGameData.level03Done = true;
                }

                if (SceneManager.GetActiveScene().name == "SpokeThreePrototype")
                {
                    NewGameData.level04Done = true;
                }




                sceneToLoad = sceneToLoad2.name;

                SceneManager.LoadScene(sceneToLoad);

                

                isSceneLoaded = true;
                Debug.Log("Scene: " + sceneToLoad + " is loaded!");


                //Resetting the Scene
                pos1 = player1SpawnPoint.transform.position;
                pos2 = player2SpawnPoint.transform.position;

                PlayerLoaderData ad = new PlayerLoaderData(pos1);
                PlayerLoaderData ad2 = new PlayerLoaderData(pos2);

                ad.Save(player1SaveString);
                ad2.Save(player2SaveString);

            }
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player1") {
			player1Trigger = true;
		
		}

		if (other.gameObject.tag == "Player2") {
			player2Trigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player1") {
			player1Trigger = false;

		}

		if (other.gameObject.tag == "Player2") {
			player2Trigger = false;
		}
	}
		
}
