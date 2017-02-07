using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonColliderRed: MonoBehaviour {

	public GameObject rightDoor;
	public Material colorChange;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Player2") {

			rightDoor.GetComponent<MeshRenderer> ().material = colorChange;

		}

	}
}
