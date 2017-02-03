using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10;
    private float jump = 5;

    private Rigidbody2D _rig;
    private string _tag;
    private int _gravityScale = 0;

    private string _directionPad;
    private string _jumpPad;
    private bool isGournd = false;

    private void Awake() {
        _rig = this.GetComponent<Rigidbody2D>();
        _tag = this.gameObject.tag;
    }

    // Use this for initialization
    void Start () {
        //Detact which player is and set control scheme
        if (_tag == "Player1") {
            _gravityScale = 1;
            _directionPad = "Horizontal";
            _jumpPad = "Jump";
        } else if (_tag == "Player2") {
            _gravityScale = -1;
            _directionPad = "GamePad_H";
            _jumpPad = "GamePad_Jump";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        _rig.velocity = new Vector2(Input.GetAxis(_directionPad) * speed, _rig.velocity.y);
        if (Input.GetButtonDown(_jumpPad) && isGournd == true) {
            _rig.AddForce(new Vector2(_rig.velocity.x, jump * _gravityScale), ForceMode2D.Impulse);
        }
    }

    //Check the player is on the ground or not;
    private void OnCollisionEnter2D(Collision2D _col) {
        if(_col.gameObject.tag == "Ground") {
            isGournd = true;
        }
    }

    private void OnCollisionExit2D(Collision2D _col) {
        if (_col.gameObject.tag == "Ground") {
            isGournd = false;
        }
    }
}
