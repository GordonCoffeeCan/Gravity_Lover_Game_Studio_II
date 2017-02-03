using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5;

    private Transform _trans;
    private Rigidbody2D _rig;

    private string _tag;

    private void Awake() {
        _trans = this.transform;
        _rig = this.GetComponent<Rigidbody2D>();

        _tag = this.gameObject.tag;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        if(_tag == "Player1") {
            _rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Physics2D.gravity.y);
        }else if(_tag == "Player2") {
            _rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, -Physics2D.gravity.y);
        }
        
    }
}
