using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatior : MonoBehaviour {
    private Rigidbody2D _rig;
    private Transform _characterSprite;
    private Animator _anim;

    private void Awake() {
        _rig = this.GetComponent<Rigidbody2D>();
        _characterSprite = this.transform.FindChild("CharacterSprite");
        _anim = _characterSprite.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(_rig.velocity.x);
	}
}
