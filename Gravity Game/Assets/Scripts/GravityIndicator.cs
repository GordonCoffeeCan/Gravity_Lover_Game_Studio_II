using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIndicator : MonoBehaviour {

    public float rotateSpeed = 2; //How fast for the rotation animation while the player is rotating to the current gravity direction;
    public Transform characterSprite; //Character sprite, which has all the animation, applied to this public variable. Instead the Indicator Arrow;

    private int _gravityAngle; //Integer equal to 0 or 180, depending on player's gravity scale is -1 or 1; When the gravity scale is -1, it is 180. Vice versa;
    private Rigidbody2D _playerRig; //Player's rigidbody;

    // Use this for initialization
    void Start () {
        _playerRig = gameObject.GetComponent<Rigidbody2D>();

        //Initialize player's rotation on start;   ------Start;
        if (_playerRig.gravityScale <= 0) {
            _gravityAngle = 180;
        } else {
            _gravityAngle = 0;
        }
        characterSprite.rotation = Quaternion.Euler(0, 0, _gravityAngle);
        //Initialize player's rotation on start;  ------End;
    }

    // Update is called once per frame
    void Update () {
        if (_playerRig.gravityScale <= 0){
            _gravityAngle = 180;
        }
        else{
            _gravityAngle = 0;
        }
        characterSprite.rotation = Quaternion.Slerp(characterSprite.rotation, Quaternion.Euler(0, 0, _gravityAngle), rotateSpeed * Time.deltaTime); //Rotating animation;
    }
}
