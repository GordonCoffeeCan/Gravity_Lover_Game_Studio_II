using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryControlScript : MonoBehaviour {

    public float speed = 10;
    public float inAirSpeed;
    public float jump = 5;
    public int gravityScale = 1;
    public int gravitySpeed;

    public static int jumpDirection;

    public float _timeCanFly = 0;
    private float _flyTimer = 5;
    private Rigidbody2D _rig;
    private string _tag;

    //private ParticleSystem _playerEffect;
    private Animator _consentHaloAnim;
    private SpriteRenderer _consentHalo;
    private Animator _playerRing; //Ring Animation to indicate switch

    private AudioSource _playerAudio;
    private float _playerAudioStartVolume;
    public bool _fadeAudio;

    private string _gravityShiftKey;

    private string _directionPad;
    private string _jumpPad;
    private bool isGournd = false;

    private bool flipped = false;

    public float speedBoost = 5;

    ///For the bar graph
    /*public float barDisplay; //current progress
    public Vector2 pos = new Vector2(60, 10);
    public Vector2 size = new Vector2(100, 10);
    public Texture2D emptyTex;
    public Texture2D fullTex;*/

    public float maxVelocity = 1;

    private void Awake()
    {
        _rig = this.GetComponent<Rigidbody2D>();
        _tag = this.gameObject.tag;
        //_playerEffect = transform.FindChild("PlayerEffect").GetComponent<ParticleSystem>();
        _consentHaloAnim = this.transform.FindChild("ConsentHalo").GetComponent<Animator>();
        _consentHalo = this.transform.FindChild("ConsentHalo").GetComponent<SpriteRenderer>();
        _playerRing = gameObject.GetComponent<Animator>(); //gets animator

        _playerAudio = gameObject.GetComponent<AudioSource>();
        _playerAudioStartVolume = 1;
        _fadeAudio = false;
    }

    // Use this for initialization
    void Start () {

        //Detect which player is and set control scheme
        if (_tag == "Player1")
        {
            gravityScale = -1;
            _directionPad = "Horizontal";
            _jumpPad = "Jump";
            _gravityShiftKey = "ShiftButton";
            _rig.gravityScale = gravityScale;
            GameData.player1GravityScale = gravityScale;
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.FindWithTag("Player2").GetComponent<Collider2D>());
            NewGameData.isPlayer1ReadytoShift = false;
        }
        else if (_tag == "Player2")
        {
            gravityScale = 1;
            _directionPad = "GamePad_H";
            _jumpPad = "GamePad_Jump";
            _gravityShiftKey = "GamePad_Shift";
            _rig.gravityScale = gravityScale;
            GameData.player2GravityScale = gravityScale;
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.FindWithTag("Player1").GetComponent<Collider2D>());
            NewGameData.isPlayer2ReadytoShift = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        _consentHalo.color = new Color(1, 1, 1, 0);

        if (GravityTrigger.inShiftRange == true)
        {
            if (Input.GetButton(_gravityShiftKey))
            {

                //_playerEffect.gameObject.SetActive(true);
                _consentHaloAnim.SetBool("ShowHalo", true);
                _playerRing.SetBool("wantsToSwitch", true); //initializes the ring animation
                _playerRing.speed = 3.0f;//speeds up the animation

                _playerAudio.volume = 1;

                if (!_playerAudio.isPlaying)
                {
                    _playerAudio.Play();
                    //Debug.Log("Audio is playing");
                }

                if (_tag == "Player1")
                {
                   NewGameData.isPlayer1ReadytoShift = true;
                   _consentHalo.color = new Color32(0, 255, 255, 255);
                    //Debug.Log("Player 1 wants to switch");
                }
                if (_tag == "Player2")
                {
                    NewGameData.isPlayer2ReadytoShift = true;
                    _consentHalo.color = Color.red;
                    //Debug.Log("Player 2 wants to switch");
                }

                if (NewGameData.isPlayer1ReadytoShift == true && NewGameData.isPlayer2ReadytoShift == true) {
                    _consentHalo.color = new Color(1, 1, 1, 1);
                }

                Debug.Log(_consentHalo.color);
            }
            else
            {
                if (_tag == "Player1")
                {
                    NewGameData.isPlayer1ReadytoShift = false;
                    //Debug.Log("Player 1 does NOT want to switch");
                }
                if (_tag == "Player2")
                {
                    NewGameData.isPlayer2ReadytoShift = false;
                    //Debug.Log("Player 2 does NOT want to switch");
                }

                //_playerEffect.gameObject.SetActive(false);
                _consentHaloAnim.SetBool("ShowHalo", false);
                _playerRing.SetBool("wantsToSwitch", false);
                _playerAudio.Stop();
            }
        }

        if(NewGameData.isPlayer1ReadytoShift == true && NewGameData.isPlayer2ReadytoShift == true)
        {
            if (_tag == "Player1")
            {
                gravityScale = 1;
                _rig.gravityScale = gravityScale;

                if (!flipped)
                {
                    //_rig.velocity = -_rig.velocity;
                    _rig.velocity = Vector2.down * speedBoost;
                    flipped = true;
                }

            }
            if (_tag == "Player2")
            {
                gravityScale = -1;
                _rig.gravityScale = gravityScale;

                if (!flipped)
                {
                    //_rig.velocity = -_rig.velocity;
                    _rig.velocity = Vector2.up * speedBoost;
                    flipped = true;
                }
            }

        }

        if (NewGameData.isPlayer1ReadytoShift == false && NewGameData.isPlayer2ReadytoShift == false)
        {
            if (_tag == "Player1")
            {
                gravityScale = -1;
                _rig.gravityScale = gravityScale;

                if (flipped)
                {
                    // _rig.velocity = -_rig.velocity;
                    _rig.velocity = Vector2.up * speedBoost;

                    flipped = false;
                }
            }
            if (_tag == "Player2")
            {
                gravityScale = 1;
                _rig.gravityScale = gravityScale;

                if (flipped)
                {
                   // _rig.velocity = -_rig.velocity;
                    _rig.velocity = Vector2.down * speedBoost;
                    flipped = false;
                }
            }
        }

        if (Input.GetButtonDown(_jumpPad) && isGournd == true)
        {
            _rig.AddForce(new Vector2(_rig.velocity.x, jump * _rig.gravityScale), ForceMode2D.Impulse);
        }

    } //end of Update

    private void FixedUpdate()
    {
        if (isGournd == true)
        {
            _rig.velocity = new Vector2(Input.GetAxis(_directionPad) * speed, _rig.velocity.y);
            _timeCanFly = _flyTimer;
        }
        else
        {
            _rig.velocity = new Vector2(Input.GetAxis(_directionPad) * inAirSpeed, _rig.velocity.y);
        }
    }

    //Check the player is on the ground or not;
    private void OnCollisionStay2D(Collision2D _col)
    {
        if (_col.gameObject.tag == "Untagged")
        {
            Debug.LogWarning("Ground Object is not tagged. Some script may not work!");
        }
        if (_col.gameObject.tag == "Ground")
        {
            isGournd = true;
        }
    }

    private void OnCollisionExit2D(Collision2D _col)
    {
        if (_col.gameObject.tag == "Untagged")
        {
            Debug.LogWarning("Ground Object is not tagged. Some script may not work!");
        }
        if (_col.gameObject.tag == "Ground")
        {
            isGournd = false;
        }


    }


}
