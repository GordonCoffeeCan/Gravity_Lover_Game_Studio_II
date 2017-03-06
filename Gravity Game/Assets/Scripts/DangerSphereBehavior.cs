using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSphereBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision _col) {
        if(_col.gameObject.tag == "Player1" || _col.gameObject.tag == "Player2") {
            Destroy(_col.gameObject);
        }
    }
}
