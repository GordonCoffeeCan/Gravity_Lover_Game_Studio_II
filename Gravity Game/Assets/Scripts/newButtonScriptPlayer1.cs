using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newButtonScriptPlayer1 : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;
	private GameObject selfButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		selfButton = gameObject;

	}

	void OnCollisionEnter2D(Collision2D col){
	
		if (col.gameObject.tag == "Player1") {
		
			Destroy (door1);
			Destroy (door2);

			Destroy (selfButton);
		
		
		}
	
	}

}
