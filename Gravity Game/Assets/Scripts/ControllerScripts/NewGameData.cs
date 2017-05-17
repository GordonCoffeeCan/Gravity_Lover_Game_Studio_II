using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameData : MonoBehaviour {

    public static bool isPlayer1ReadytoShift = false;
    public static bool isPlayer2ReadytoShift = false;

    public static float player1GravityScale = 1;
    public static float player2GravityScale = -1;

    public static bool tutorialLevelDone = true;
    public static bool level02Done = true;
    public static bool level03Done = false;
    public static bool level04Done = false;

    public static string previousLevelName = null;

    public static bool player1isDead = false;
    public static bool player2isDead = false;

    public static Quaternion currentEnvPivotAngle;


    public static bool paused = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
