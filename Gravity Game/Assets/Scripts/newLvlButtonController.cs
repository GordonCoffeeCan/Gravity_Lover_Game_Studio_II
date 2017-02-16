using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLvlButtonController : MonoBehaviour {
	public Renderer door;
	public GameObject redButton1;
	public GameObject greenButton1;
	public GameObject redButton2;
	public GameObject greenButton2;
	public GameObject redButton3;
	public GameObject greenButton3;
	public GameObject redButton4;
	public GameObject greenButton4;


	public GameObject redDoor1a;
	public GameObject redDoor1b;
	public GameObject greenDoor1a;
	public GameObject greenDoor1b;
	public GameObject redDoor2;
	public GameObject greenDoor2;
	public GameObject redDoor3a;
	public GameObject redDoor3b;
	public GameObject greenDoor3a;
	public GameObject greenDoor3b;
	public GameObject redDoor4;
	public GameObject greenDoor4;

	private string newObjName;
	// Use this for initialization
	void Start () {
		newObjName = this.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D _col) {

		//leftDoor.GetComponent<MeshRenderer> ().material = colorChange;


		if ((newObjName == "greenButton1" && _col.gameObject.tag == "Player1") || (newObjName == "redButton1" && _col.gameObject.tag == "Player2")) {
			ActivateDoor();
		}
	}

	private void ActivateDoor() {
		//Do something for the door here!
		Debug.Log("Door Activated!");
		Debug.Log (newObjName);

		if(newObjName == "GreenDoor_1a") {
			door = GetComponent<Renderer>();
			Debug.Log (door);
			door.material.color = Color.green;
		
		}else if (newObjName == "RedDoor_1a") {
//			this.gameObject.material.color = Color.red;

		}
	}
}
