using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCarrierBehavior : MonoBehaviour {

    public float launchTimer = 1;

    private bool _player1On;
    private bool _player2On;

    private float _launchTimer;

    private Animator _anim;

	// Use this for initialization
	void Start () {
        _player1On = false;
        _player2On = false;

        _launchTimer = launchTimer;

        _anim = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if(this.name == "PlayerCarrier") {
            if (_player1On == true && _player2On == true) {
                _launchTimer -= Time.deltaTime;
                if (_launchTimer <= 0) {
                    _anim.SetBool("PlayersOn", true);
                }
            } else {
                _launchTimer = launchTimer;
            }
        }

        if (this.name == "KeyMover") {
            if (_player1On == true && _player2On == true) {
                if (GameData.isKey1Collected == true && GameData.isKey2Collected == true) {
                    GameObject.Find("KeyDoor_1").GetComponent<Animator>().SetBool("Open", true);
                    GameObject.Find("KeyDoor_2").GetComponent<Animator>().SetBool("Open", true);
                    _launchTimer -= Time.deltaTime;
                    if (_launchTimer <= 0) {
                        _anim.SetBool("PlayersOn", true);
                    }
                }
            } else {
                _launchTimer = launchTimer;
            }
        }
        
		
	}

    private void OnCollisionStay2D(Collision2D _col) {
        if(_col.gameObject.tag == "Player1") {
            _col.gameObject.transform.SetParent(this.transform);
            _player1On = true;
        }else if(_col.gameObject.tag == "Player2") {
            _col.gameObject.transform.SetParent(this.transform);
            _player2On = true;
        }
    }

    private void OnCollisionExit2D(Collision2D _col) {
        if (_col.gameObject.tag == "Player1") {
            _col.gameObject.transform.SetParent(null);
            _player1On = false;
        }else if(_col.gameObject.tag == "Player2") {
            _player2On = false;
            _col.gameObject.transform.SetParent(null);
        }
    }
}
