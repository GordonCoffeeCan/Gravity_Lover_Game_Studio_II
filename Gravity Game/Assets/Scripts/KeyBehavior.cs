using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D _col) {
        if(this.gameObject.name == "Key_1" &&  _col.tag == "Player1") {
            GameData.isKey1Collected = true;
            Destroy(this.gameObject);

        }else if (this.gameObject.name == "Key_2" && _col.tag == "Player2") {
            GameData.isKey2Collected = true;
            Destroy(this.gameObject);
        }
    }
}
