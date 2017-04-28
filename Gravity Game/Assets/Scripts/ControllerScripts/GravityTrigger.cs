using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GravityTrigger : MonoBehaviour {

    public float range = 10; //how close the objects need to be to each other to gravity shift;
    public float separateRange = 60; //How far the players that will separate them to fail the game;

    private Transform player1;
    private Transform player2;
    private float distance;

    private Light glow1;
    private Light glow2;

    private float distancePercentage;

    public static bool inShiftRange = false;

    public static Vector3 middlePoint;
    public static Vector3 player1Pos;
    public static Vector3 player2Pos;

    private string currentScene;

    private string _tag;

    //camerShake

   

    //CameraShakeEnd


    //RedOverLay

    public Image panel; 



    private void Start() {

        currentScene = SceneManager.GetActiveScene().name;

        player1 = GameObject.FindWithTag("Player1").transform;
        player2 = GameObject.FindWithTag("Player2").transform;

        glow1 = player1.FindChild("Point light").GetComponent<Light>();
        glow2 = player2.FindChild("Point light").GetComponent<Light>();

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

        //distancePercentage = distance*0.00002f*255;
        if (distance > 2/5 * separateRange)
        {
            distancePercentage = ((distance / separateRange) * 25) * Time.deltaTime;
        }
        else
        {
            distancePercentage = 0;
        }

        panel.color = new Color(255, 0, 0, distancePercentage);

        
	}

    void inRange()
    {
        if (distance <= range)
        {
            glow1.enabled = true;
            glow2.enabled = true;
            inShiftRange = true;

            
            
        }
        else
        {
            glow1.enabled = false;
            glow2.enabled = false;
            inShiftRange = false;

            
        }

      

    }

    void OutRange() {
        if(distance >= separateRange) {
            SceneManager.LoadScene(currentScene); 
        }
    }

   
}
