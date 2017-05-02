using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTriggerScript : MonoBehaviour {
    public Animator elevatorAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D _col) {
        if (_col.gameObject.tag == "Player2") {
            if(elevatorAnim != null) {
                elevatorAnim.SetBool("GoDown", true);
            }
        }
    }
}
