using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatior : MonoBehaviour {
    private Rigidbody2D _rig;
    private Transform _characterSprite;
    private Animator _anim;

    RaycastHit2D _rayHit;

    private void Awake() {
        _rig = this.GetComponent<Rigidbody2D>();
        _characterSprite = this.transform.FindChild("CharacterSprite");
        _anim = _characterSprite.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        Debug.Log(_rig.velocity.x);

        if ((_rig.velocity.x * _rig.gravityScale) > 0) {
            _anim.SetFloat("Speed", 1);
            _anim.SetLayerWeight(1, 0);
        } else if ((_rig.velocity.x * _rig.gravityScale) == 0) {
            _anim.SetFloat("Speed", 0);
        } else {
            _anim.SetFloat("Speed", 1);
            _anim.SetLayerWeight(1, 1);
        }

        if(Mathf.Abs(_rig.velocity.y) > 0.1f) {
            _anim.SetBool("InTheAir", true);
        } else {
            _anim.SetBool("InTheAir", false);
        }
    }
}
