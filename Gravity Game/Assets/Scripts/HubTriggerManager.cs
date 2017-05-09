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
                DoorAnim(1, true);
                DoorAnim(2, true);
                if (NewGameData.level02Done == false) {
                    HubManager._level02Portal.SetActive(true);
                }
                if(NewGameData.level03Done == false) {
                    HubManager._level03Portal.SetActive(true);
                }
                
                RotateHub();
                break;
            case "Door2CloseTrigger":
                if (NewGameData.level02Done == true) {
                    DoorAnim(1, false);
                }
                RotateHub();
                break;
            case "Door3CloseTrigger":
                if (NewGameData.level03Done == true) {
                    DoorAnim(2, false);
                }
                if (NewGameData.level04Done == false) {
                    HubManager._level04Portal.SetActive(true);
                }
                RotateHub();
                break;
            case "Door4CloseTrigger":
                //DoorAnim(3, false);
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

    private void RotateHub() {
        if (playerPREntered == true && playerJPEntered == true) {
            if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == false && NewGameData.level03Done == false) {
                HubManager.levelState = HubManager.LevelState.level01Finished;
            }

            if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == true && NewGameData.level03Done == true) {
                HubManager.levelState = HubManager.LevelState.level02And03Finished;
                DoorAnim(3, true);
            }

            if (NewGameData.level04Done == true) {

            }
        }
    }
}
