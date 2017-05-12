using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatior : MonoBehaviour {
    private Rigidbody2D _rig;
    private Transform _characterSprite;
    private Animator _anim;

    private string _gravityShiftKey;

    RaycastHit2D _rayHit;

    private void Awake() {
        _rig = this.GetComponent<Rigidbody2D>();
        _characterSprite = this.transform.FindChild("SpriteHolder/CharacterSprite");
        _anim = _characterSprite.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        //Detect which player is and set control scheme
        if (this.tag == "Player1") {
            _gravityShiftKey = "ShiftButton";
        } else if (this.tag == "Player2") {
            _gravityShiftKey = "GamePad_Shift";
        }
    }

    // Update is called once per frame
    void Update() {

        if (NewGameData.player1isDead == true || NewGameData.player2isDead == true) {
            return;
        }

        if ((_rig.velocity.x * _rig.gravityScale) > 0) {
            _anim.SetFloat("Speed", 1);
            _anim.SetLayerWeight(1, 0);
        }else if ((_rig.velocity.x * _rig.gravityScale) < 0) {
            _anim.SetFloat("Speed", 1);
            _anim.SetLayerWeight(1, 1);
        } else if((_rig.velocity.x * _rig.gravityScale) == 0) {
            _anim.SetFloat("Speed", 0);

        }
        

        if(Mathf.Abs(_rig.velocity.y) > 0.2f) {
            _anim.SetBool("InTheAir", true);
        } else {
            _anim.SetBool("InTheAir", false);
        }

        if (Input.GetButton(_gravityShiftKey)) {
            _anim.SetBool("Consent", true);
        } else {
            _anim.SetBool("Consent", false);
        }
    }
}
