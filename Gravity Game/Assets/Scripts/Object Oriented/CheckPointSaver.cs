using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSaver : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject[] player1Pos = GameObject.FindGameObjectsWithTag("Player1");

        Vector3 pos = player1Pos[0].transform.position;
        

        PlayerLoaderData ad = new PlayerLoaderData(pos);

        ad.Save("Player1Position.txt");

        //---------------------------------------------------------

        GameObject[] player2Pos = GameObject.FindGameObjectsWithTag("Player2");

        Vector3 pos2 = player2Pos[0].transform.position;


        PlayerLoaderData ad2 = new PlayerLoaderData(pos2);

        ad2.Save("Player2Position.txt");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
