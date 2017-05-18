using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class thankYouScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NewGameData.tutorialLevelDone = false;
        NewGameData.level02Done = false;
        NewGameData.level03Done = false;
        NewGameData.level04Done = false;
    }

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("ShiftButton") || Input.GetButtonDown("GamePad_Shift")) {
			SceneManager.LoadScene ("startScene");	
		}

	}
}
