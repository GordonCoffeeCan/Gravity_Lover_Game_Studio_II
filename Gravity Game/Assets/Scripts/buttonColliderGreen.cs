using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonColliderGreen: MonoBehaviour {
	
	public GameObject leftDoor;
	public Material colorChange;
	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Player1") {

			leftDoor.GetComponent<MeshRenderer> ().material = colorChange;

		}

	}
}
