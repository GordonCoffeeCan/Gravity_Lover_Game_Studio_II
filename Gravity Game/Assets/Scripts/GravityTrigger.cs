﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour {

    public Transform marker;

    private Transform player1;
    private Transform player2;
    private float distance;

    public float range; //how close the objects need to be to each other to gravity shift;
    public float minRange; //how close the players will stop moving toward from each other;

    private Light glow1;
    private Light glow2;

    public static bool inShiftRange = false;

    public static Vector3 middlePoint;

    private string _tag;

    private void Awake() {
        player1 = GameObject.Find("Player1").transform;
        player2 = GameObject.Find("Player2").transform;

        glow1 = player1.FindChild("Point light").GetComponent<Light>();
        glow2 = player2.FindChild("Point light").GetComponent<Light>();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(player1.position, player2.position);
        middlePoint = (player1.position + player2.position) / 2;

        if(marker != null) {
            marker.position = middlePoint;
        }
        inRange();
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
}
