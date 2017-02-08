using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    //public GameObject leftDoor;
    //public Material colorChange;

    public Animator elevator;

    private string objectName;
    private Animator buttonAnim;

    private void Awake() {
        objectName = this.gameObject.name;
        buttonAnim = this.gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {

	}

	private void OnCollisionEnter2D(Collision2D _col) {

        //leftDoor.GetComponent<MeshRenderer> ().material = colorChange;

        if ((objectName == "GreenBtn_Elevator" && _col.gameObject.tag == "Player1") || (objectName == "RedBtn_Elevator" && _col.gameObject.tag == "Player2")) {
            ActivateElevator();
        }

        if ((objectName == "GreenBtn_Door" && _col.gameObject.tag == "Player1") || (objectName == "RedBtn_Door" && _col.gameObject.tag == "Player2")) {
            ActivateDoor();
        }
    }

    private void ActivateElevator() {
        buttonAnim.SetBool("isPressed", true);
        elevator.GetComponent<Animator>().SetBool("isActivated", true);
    }

    private void ActivateDoor() {
        //Do something for the door here!
        Debug.Log("Door Activated!");
        buttonAnim.SetBool("isPressed", true);
    }
}
