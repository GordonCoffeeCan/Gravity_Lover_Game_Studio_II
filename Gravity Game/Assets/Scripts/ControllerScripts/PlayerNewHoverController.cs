using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewHoverController : MonoBehaviour
{
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

    private ParticleSystem _playerEffect;
    private Animator _playerRing; //Ring Animation to indicate switch

    private AudioSource _playerAudio;
    private float _playerAudioStartVolume;
    public bool _fadeAudio;

    private string _gravityShiftKey;

    private string _directionPad;
    private string _jumpPad;
    private bool isGournd = false;

    ///For the bar graph
    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(60, 10);
    public Vector2 size = new Vector2(100, 10);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    public float maxVelocity = 1;

    private void Awake()
    {
        _rig = this.GetComponent<Rigidbody2D>();
        _tag = this.gameObject.tag;
        _playerEffect = transform.FindChild("PlayerEffect").GetComponent<ParticleSystem>();
        _playerRing = gameObject.GetComponent<Animator>(); //gets animator

        _playerAudio = gameObject.GetComponent<AudioSource>();
        _playerAudioStartVolume = 1;
        _fadeAudio = false;
    }

    // Use this for initialization
    void Start()
    {
      

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
        }


        inAirSpeed = speed * 0.8f;
        _timeCanFly = _flyTimer;
    }


    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }


    // Update is called once per frame
    void Update()
    {
        //CheckControllerStatus();

       

        if (_rig.velocity.magnitude > maxVelocity)
        {
            _rig.velocity = _rig.velocity.normalized * maxVelocity;
        }


        if (GravityTrigger.inShiftRange == true)
        {
            if (Input.GetButton(_gravityShiftKey))
            {
                
                    _playerEffect.gameObject.SetActive(true);
                    _playerRing.SetBool("wantsToSwitch", true); //initializes the ring animation
                    _playerRing.speed = 3.0f;//speeds up the animation

                    _playerAudio.volume = _playerAudioStartVolume;

                    if (!_playerAudio.isPlaying)
                    {
                        _playerAudio.Play();
                    }


                    if (_tag == "Player1")
                    {
                        GameData.isPlayer1ReadytoHover = true;
                    }
                    else if (_tag == "Player2")
                    {
                        GameData.isPlayer2ReadytoHover = true;
                        
                    }

                if (GameData.isPlayer1ReadytoHover == true && GameData.isPlayer2ReadytoHover == true)
                    {
                        GameData.player1GravityScale = -1*gravitySpeed;
                        GameData.player2GravityScale = 1* gravitySpeed;


                    }

                    if (_tag == "Player1")
                    {
                        _rig.gravityScale = GameData.player1GravityScale;
                        GameObject.Find("Player2").GetComponent<Rigidbody2D>().gravityScale = GameData.player2GravityScale;
                    }
                    else if (_tag == "Player2")
                    {
                        _rig.gravityScale = GameData.player2GravityScale;
                        GameObject.Find("Player1").GetComponent<Rigidbody2D>().gravityScale = GameData.player1GravityScale;
                    }
                    NotReadyToShiftGravity();
                

            }
            else if (Input.GetButtonUp(_gravityShiftKey))
            {


                if (GameData.isPlayer1ReadytoHover == true && GameData.isPlayer2ReadytoHover == true) {
                    GameData.player1GravityScale *= -1;
                    GameData.player2GravityScale *= -1;

                    
                }



                if (_tag == "Player1")
                {
                    _rig.gravityScale = GameData.player1GravityScale;
                    GameObject.FindWithTag("Player2").GetComponent<Rigidbody2D>().gravityScale = GameData.player2GravityScale;
                    //GameData.isPlayer1ReadytoHover = false;


                }
                else if (_tag == "Player2")
                {
                    _rig.gravityScale = GameData.player2GravityScale;
                    GameObject.FindWithTag("Player1").GetComponent<Rigidbody2D>().gravityScale = GameData.player1GravityScale;
                    //GameData.isPlayer2ReadytoHover = false;
                }
                NotReadyToShiftGravity();

                
                    


                
            }
        }
        else
        {
            NotReadyToShiftGravity();
        }

        if (Input.GetButtonDown(_jumpPad) && isGournd == true)
        {
            _rig.AddForce(new Vector2(_rig.velocity.x, jump * _rig.gravityScale), ForceMode2D.Impulse);
        }


        

    }

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

    private void NotReadyToShiftGravity()
    {
        GameData.isPlayer1ReadytoHover = false;
        GameData.isPlayer2ReadytoHover = false;

        if (_tag == "Player1")
        {
            _rig.gravityScale = GameData.player1GravityScale;
            GameObject.FindWithTag("Player2").GetComponent<Rigidbody2D>().gravityScale = GameData.player2GravityScale;
        }
        else if (_tag == "Player2")
        {
            _rig.gravityScale = GameData.player2GravityScale;
            GameObject.FindWithTag("Player1").GetComponent<Rigidbody2D>().gravityScale = GameData.player1GravityScale;
        }

        _playerEffect.gameObject.SetActive(false);
        _playerRing.SetBool("wantsToSwitch", false);
        _playerAudio.Stop();


    }

    private void FlyingTimer()
    {
        _timeCanFly -= Time.deltaTime;

        if (_timeCanFly <= 0)
        {
            _timeCanFly = 0;
        }
    }
}