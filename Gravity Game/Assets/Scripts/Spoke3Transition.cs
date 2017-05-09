using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Spoke3Transition : MonoBehaviour {

    public bool player1Trigger = false;

    public bool player2Trigger = false;

    private bool isSceneLoaded = false;

    public string sceneToLoad;

    public Object sceneToLoad2;

    public GameObject otherTrigger;
    public bool isTriggered;
    

    //For Resetting scene
    private Vector3 pos1;
    private Vector3 pos2;

    public string player1SaveString;
    public string player2SaveString;

    public GameObject player1SpawnPoint;
    public GameObject player2SpawnPoint;



    private void Awake()
    {
        isSceneLoaded = false;
    }

    void Update()
    {
        if (isTriggered == true && otherTrigger.GetComponent<Spoke3Transition>().isTriggered == true)
        {
            if (isSceneLoaded == false)
            {

                //sceneToLoad = sceneToLoad2.name;

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

        if (other.gameObject.tag == "Player1" || other.gameObject.tag =="Player2")
        {
            isTriggered = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            isTriggered = false;

        }
    }
}
