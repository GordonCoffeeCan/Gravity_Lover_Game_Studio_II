using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionScript : MonoBehaviour {

	public bool player1Trigger = false;
	public bool player2Trigger = false;
	public string sceneManager;

	void Update (){
		if (player1Trigger == true && player2Trigger == true) {
			SceneManager.LoadScene (sceneManager);
			Debug.Log ("test");
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
