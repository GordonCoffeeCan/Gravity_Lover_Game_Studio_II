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
                DoorAnim(0, true);
                break;
            case "Door2Trigger":
                DoorAnim(1, true);
                break;
            case "Door3Trigger":
                DoorAnim(2, true);
                break;
            case "Door4Trigger":
                DoorAnim(3, true);
                break;
            case "Door1CloseTrigger":
                DoorAnim(0, false);
                break;
            case "Door2CloseTrigger":
                DoorAnim(1, false);
                break;
            case "Door3CloseTrigger":
                DoorAnim(2, false);
                break;
            case "Door4CloseTrigger":
                DoorAnim(3, false);
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

    private void DoorAnim(int _index, bool _isOpen) {
        if (playerPREntered == true && playerJPEntered == true) {
            HubManager.doors[_index].SetBool("Open", _isOpen);
        }
    }
}
