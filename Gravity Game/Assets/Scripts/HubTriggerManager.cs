using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubTriggerManager : MonoBehaviour {

    private bool playerPREntered = false;
    private bool playerJPEntered = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        switch (this.name) {
            case "Door1Trigger":
                if (playerPREntered == true && playerJPEntered == true) {
                    HubManager.door1.SetBool("Open", true);
                }
                break;
            case "Door2Trigger":

                break;
            case "Door3Trigger":

                break;
            case "Door4Trigger":

                break;
            case "Door1CloseTrigger":
                break;
            case "Door2CloseTrigger":
                break;
            case "Door3CloseTrigger":
                break;
            case "Door4CloseTrigger":
                break;
        }
	}

    private void OnTriggerEnter2D(Collider2D _col) {
        if(_col.tag == "Player1") {
            playerPREntered = true;
        }

        if (_col.tag == "Player2") {
            playerJPEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _col) {
        if (_col.tag == "Player1") {
            playerPREntered = false;
        }

        if (_col.tag == "Player2") {
            playerJPEntered = false;
        }
    }
}
