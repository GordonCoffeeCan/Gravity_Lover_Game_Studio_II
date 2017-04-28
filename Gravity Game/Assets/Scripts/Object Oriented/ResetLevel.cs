using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {

    private Vector3 pos1;
    private Vector3 pos2;

    public string player1SaveString;
    public string player2SaveString;

    public GameObject player1SpawnPoint;
    public GameObject player2SpawnPoint;

    private string currentScene;


    // Use this for initialization
    void Start () {

        currentScene = SceneManager.GetActiveScene().name;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("Scene Reset");

            pos1 = player1SpawnPoint.transform.position;
            pos2 = player2SpawnPoint.transform.position;

            PlayerLoaderData ad = new PlayerLoaderData(pos1);
            PlayerLoaderData ad2 = new PlayerLoaderData(pos2);

            ad.Save(player1SaveString);
            ad2.Save(player2SaveString);

            SceneManager.LoadScene(currentScene);

        }


            
    }

    public void Reset()
    {
        Debug.Log("Scene Reset");

        pos1 = player1SpawnPoint.transform.position;
        pos2 = player2SpawnPoint.transform.position;

        PlayerLoaderData ad = new PlayerLoaderData(pos1);
        PlayerLoaderData ad2 = new PlayerLoaderData(pos2);

        ad.Save(player1SaveString);
        ad2.Save(player2SaveString);
        Time.timeScale = 1f;

        SceneManager.LoadScene("startScene");

    }
}
