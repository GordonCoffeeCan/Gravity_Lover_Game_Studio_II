using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;

	// Use this for initialization
	void Start () {
        player1 = GameObject.FindWithTag("Player1").gameObject;
        player2 = GameObject.FindWithTag("Player2").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player1.GetComponent<PlayerHoveringController>().enabled = true;
            player2.GetComponent<PlayerHoveringController>().enabled = true;

            player1.GetComponent<PlayerNewHoverController>().enabled = false;
            player2.GetComponent<PlayerNewHoverController>().enabled = false;

            player1.GetComponent<BinaryControlScript>().enabled = false;
            player2.GetComponent<BinaryControlScript>().enabled = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player1.GetComponent<PlayerHoveringController>().enabled = false;
            player2.GetComponent<PlayerHoveringController>().enabled = false;

            player1.GetComponent<PlayerNewHoverController>().enabled = true;
            player2.GetComponent<PlayerNewHoverController>().enabled = true;

            player1.GetComponent<BinaryControlScript>().enabled = false;
            player2.GetComponent<BinaryControlScript>().enabled = false;

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player1.GetComponent<PlayerHoveringController>().enabled = false;
            player2.GetComponent<PlayerHoveringController>().enabled = false;

            player1.GetComponent<PlayerNewHoverController>().enabled = false;
            player2.GetComponent<PlayerNewHoverController>().enabled = false;

            player1.GetComponent<BinaryControlScript>().enabled = true;
            player2.GetComponent<BinaryControlScript>().enabled = true;

        }

    }
}
