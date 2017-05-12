using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GravityTrigger : MonoBehaviour {

    public float range = 10; //how close the objects need to be to each other to gravity shift;
    public float separateRange = 60; //How far the players that will separate them to fail the game;

    public Animator BlackCover;

    private Transform player1;
    private Transform player2;
    private float distance;

    //private Light glow1;
    //private Light glow2;

    private float distancePercentage;

    public static bool inShiftRange = false;

    public static Vector3 middlePoint;
    public static Vector3 player1Pos;
    public static Vector3 player2Pos;

    private string currentScene;

    private Animator _player1Anim;
    private Animator _player2Anim; 

    private string _tag;

    //camerShake

   

    //CameraShakeEnd


    //RedOverLay

    public Image panel;

    private void Start() {

        currentScene = SceneManager.GetActiveScene().name;

        player1 = GameObject.FindWithTag("Player1").transform;
        player2 = GameObject.FindWithTag("Player2").transform;

        _player1Anim = player1.FindChild("SpriteHolder/CharacterSprite").GetComponent<Animator>();
        _player2Anim = player2.FindChild("SpriteHolder/CharacterSprite").GetComponent<Animator>();

        //glow1 = player1.FindChild("Point light").GetComponent<Light>();
        //glow2 = player2.FindChild("Point light").GetComponent<Light>();

        _player1Anim.SetBool("DeathBySeperate", false);
        _player2Anim.SetBool("DeathBySeperate", false);

        NewGameData.player1isDead = false;
        NewGameData.player2isDead = false;

    }

    // Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
        
        distance = Vector3.Distance(player1.position, player2.position);
        middlePoint = (player1.position + player2.position) / 2;

        player1Pos = player1.position;
        player2Pos = player2.position;

        inRange();
        OutRange();

        if (distance > (0.4 * separateRange)) //0.4 is minimum
        {
            distancePercentage = distance / separateRange;
        }
        else
        {
            distancePercentage = 0;
        }

        panel.color = new Color(1, 1, 1, Mathf.Lerp(panel.color.a, Mathf.Clamp(distancePercentage, 0, 0.35f), 2.5f * Time.deltaTime));
	}

    void inRange()
    {
        if (distance <= range)
        {
            inShiftRange = true;
        }
        else
        {
            inShiftRange = false;
        }
    }

    void OutRange() {
        if(distance >= separateRange) {

            _player1Anim.SetBool("DeathBySeperate", true);
            _player2Anim.SetBool("DeathBySeperate", true);

            NewGameData.player1isDead = true;
            NewGameData.player2isDead = true;

            Invoke("BlackFadeOut", 0.5f);
        }
    }

    private void BlackFadeOut() {
        BlackCover.SetTrigger("CoverScene");
        panel.color = new Color(1, 1, 1, Mathf.Lerp(panel.color.a, 0, 13 * Time.deltaTime));
        Invoke("Restart", 0.5f);
    }

    void Restart()
    {
        DontDestroyOnLoad(GameManager.musicSource);
        SceneManager.LoadScene(currentScene);
    }
}
