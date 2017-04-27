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

    public Vector3 originalCameraPosition;

    float shakeAmt = 0;

    public Camera mainCamera;

    public Rigidbody2D rb;
    
   

    private float minimumRange=5;

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

        distancePercentage = distance*0.00002f*255;

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

        if (distance <= minimumRange)
        {
            
            shakeAmt = 0;
            //StopShaking();
        }
        else
        {
            shakeAmt = distance * 1000;
            CameraShake();
        }

    }

    void OutRange() {
        if(distance >= separateRange) {
            SceneManager.LoadScene(currentScene); 
        }
    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.x += quakeAmt; // can also add to x and/or z
            mainCamera.transform.position = pp;

            Debug.Log("CameraShake");
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }
}
