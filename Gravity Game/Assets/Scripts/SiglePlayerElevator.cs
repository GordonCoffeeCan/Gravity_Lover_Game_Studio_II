using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiglePlayerElevator : MonoBehaviour {

    private Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D _col) {
        if(_col.gameObject.tag == "Player2") {
            Invoke("TriggerAnim", 1.2f);
        }
    }

    private void TriggerAnim() {
        _anim.SetBool("GoUp", true);
    }
}
