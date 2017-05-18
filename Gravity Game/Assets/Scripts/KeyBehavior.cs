using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour {
    public string sceneName;
    public Animator doorA;
    public Animator doorB;
	public AudioSource keySFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D _col) {
        if((this.gameObject.name == "Key_1" || this.gameObject.name == "Key A") &&  _col.tag == "Player1") {
            GameData.isKey1Collected = true;

            if(sceneName == "SpokeTwoPrototype") {
                if(doorA != null) {
                    doorA.SetBool("Open", true);
                    //keySFX.Play ();
                }
            }

            Destroy(this.gameObject);

        }else if ((this.gameObject.name == "Key_2" || this.gameObject.name == "Key B") && _col.tag == "Player2") {
            GameData.isKey2Collected = true;

            if (sceneName == "SpokeTwoPrototype") {
                if (doorB != null) {
                    doorB.SetBool("Open", true);
                    //keySFX.Play ();
                }
            }

            Destroy(this.gameObject);
        }
    }
}
