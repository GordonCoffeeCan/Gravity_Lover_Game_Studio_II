using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10;
    public float inAirSpeed;
    public float jump = 5;

    public static int jumpDirection;

    private Rigidbody2D _rig;
    private string _tag;
    private int _gravityScale = 0;

    private string _gravityShiftKey;

    private string _directionPad;
    private string _jumpPad;
    private bool isGournd = false;

    private void Awake() {
        _rig = this.GetComponent<Rigidbody2D>();
        _tag = this.gameObject.tag;
    }

    // Use this for initialization
    void Start () {
        //Detect which player is and set control scheme
        if (_tag == "Player1") {
            _gravityScale = 1;
            _directionPad = "Horizontal";
            _jumpPad = "Jump";
            _gravityShiftKey = "ShiftButton";
        } else if (_tag == "Player2") {
            _gravityScale = -1;
            _directionPad = "GamePad_H";
            _jumpPad = "GamePad_Jump";
            _gravityShiftKey = "GamePad_Shift";
        }

        inAirSpeed = speed * 0.8f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp(_gravityShiftKey)) {
            if (GravityTrigger.canShift == true) {
                _gravityScale *= -1;
                _rig.gravityScale *= -1;
            }
        }

        if (Input.GetButtonDown(_jumpPad) && isGournd == true) {
            _rig.AddForce(new Vector2(_rig.velocity.x, jump * _gravityScale), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate() {
        if(isGournd == true) {
            _rig.velocity = new Vector2(Input.GetAxis(_directionPad) * speed, _rig.velocity.y);
        } else {
            _rig.velocity = new Vector2(Input.GetAxis(_directionPad) * inAirSpeed, _rig.velocity.y);
        }
    }

    //Check the player is on the ground or not;
    private void OnCollisionStay2D(Collision2D _col) {
        if (_col.gameObject.tag == "Untagged") {
            Debug.LogWarning("Ground Object is not tagged. Some script may not work!");
        }
        if(_col.gameObject.tag == "Ground") {
            isGournd = true;
        }
    }

    private void OnCollisionExit2D(Collision2D _col) {
        if (_col.gameObject.tag == "Untagged") {
            Debug.LogWarning("Ground Object is not tagged. Some script may not work!");
        }
        if (_col.gameObject.tag == "Ground") {
            isGournd = false;
        }
    }
}
