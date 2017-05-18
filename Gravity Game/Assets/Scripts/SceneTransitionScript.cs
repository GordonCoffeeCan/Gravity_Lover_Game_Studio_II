using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionScript : MonoBehaviour {

    public Animator BlackCover;
    public Image panel;
    public float colorLerpTime = 3;
    private float time = 0;


	public bool player1Trigger = false;

	public bool player2Trigger = false;

    private bool isSceneLoaded = false;

	public string sceneToLoad;

    private GameObject player1;
    private GameObject player2;

   // public Object sceneToLoad2;
  


    //For Resetting scene
    private Vector3 pos1;
    private Vector3 pos2;

    public string player1SaveString;
    public string player2SaveString;

    public GameObject player1SpawnPoint;
    public GameObject player2SpawnPoint;

    private AudioSource gameEndSFX;
    private GameObject particle;


    private void Awake() {
        isSceneLoaded = false;

        gameEndSFX = GameObject.FindGameObjectWithTag("LevelEndSFX").GetComponent<AudioSource>();

        particle = this.gameObject.transform.GetChild(0).gameObject;
    }

    void Update (){
		if (player1Trigger == true && player2Trigger == true) {

            gameEndSFX.Play();
			GameManager.musicSource.blackFade = true;

            Invoke("sceneChange", 4);


            player1 = GameObject.FindGameObjectWithTag("Player1").gameObject;
            player2 = GameObject.FindGameObjectWithTag("Player2").gameObject;

            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(false);

            // this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 4));
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, 30);

            if (time < 3)
            {
                time += Time.deltaTime / colorLerpTime;
            }

            particle.SetActive(false);

            Invoke("BlackFadeOut", 1);

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

    private void BlackFadeOut()
    {
        BlackCover.SetTrigger("CoverScene");
        panel.color = new Color(1, 1, 1, Mathf.Lerp(panel.color.a, 0, 13 * Time.deltaTime));

        


    }

    void sceneChange()
    {
        if (isSceneLoaded == false)
        {

            if (SceneManager.GetActiveScene().name == "tutorialScene")
            {
                NewGameData.previousLevelName = "tutorialScene";
                NewGameData.tutorialLevelDone = true;
            }

            if (SceneManager.GetActiveScene().name == "SpokeOnePrototype")
            {
                NewGameData.previousLevelName = "SpokeOnePrototype";
                NewGameData.level02Done = true;
            }

            if (SceneManager.GetActiveScene().name == "SpokeTwoPrototype")
            {
                NewGameData.previousLevelName = "SpokeTwoPrototype";
                NewGameData.level03Done = true;
            }

            if (SceneManager.GetActiveScene().name == "SpokeThreePrototype")
            {
                NewGameData.previousLevelName = "SpokeThreePrototype";
                NewGameData.level04Done = true;
            }




            // sceneToLoad = sceneToLoad2.name;
            if (GameManager.musicSource != null)
            {
                Destroy(GameManager.musicSource.gameObject);
            }
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

        this.gameObject.SetActive(false);
    }
		
}

