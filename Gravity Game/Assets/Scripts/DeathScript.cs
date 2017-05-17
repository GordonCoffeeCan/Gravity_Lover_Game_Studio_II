using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {

    private string currentScene;
	
    public float deathDelay = 1.0f;
    private Transform player1;
    private Transform player2;

    private Animator _player1Anim;
    private Animator _player2Anim;


    private AudioSource deathSFXSound;

    // Use this for initialization
    void Start () {
        currentScene = SceneManager.GetActiveScene().name;
        if (GameManager.musicSource != null) {
            //GameManager.musicSource.blackFade = false;
        }

        player1 = GameObject.FindWithTag("Player1").transform;
        player2 = GameObject.FindWithTag("Player2").transform;

        _player1Anim = player1.FindChild("SpriteHolder/CharacterSprite").GetComponent<Animator>();
        _player2Anim = player2.FindChild("SpriteHolder/CharacterSprite").GetComponent<Animator>();

        _player1Anim.SetBool("DeathByBurn", false);
        _player2Anim.SetBool("DeathByBurn", false);

        NewGameData.player1isDead = false;
        NewGameData.player2isDead = false;

        deathSFXSound = GameObject.FindGameObjectWithTag("DeathSFX").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
       if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {

            if(GameManager.musicSource != null) {
                //GameManager.musicSource.blackFade = true;
            }

            //player1.gameObject.SetActive(false);
            //player2.gameObject.SetActive(false);

            if (collider.gameObject.tag == "Player1") {
                PlayerBurned(_player1Anim);

                deathSFXSound.Play();
                
            }else if (collider.gameObject.tag == "Player2") {
                PlayerBurned(_player2Anim);


                deathSFXSound.Play();
            }
        }

        NewGameData.player1isDead = true;
        NewGameData.player2isDead = true;
    }

    private void PlayerBurned(Animator _anim) {
        _anim.SetBool("DeathByBurn", true);

        Invoke("Restart", 0.5f);
    }

    private void BlackFadeOut() {
        GameObject.Find("GameManager").GetComponent<GravityTrigger>().BlackCover.SetTrigger("CoverScene");

        Invoke("Restart", 0.5f);
    }

    void Restart() {
        DontDestroyOnLoad(GameManager.musicSource);
        SceneManager.LoadScene(currentScene);
    }

}
