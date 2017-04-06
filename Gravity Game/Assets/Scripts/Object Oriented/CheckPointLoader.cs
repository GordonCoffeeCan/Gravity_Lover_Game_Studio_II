using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        PlayerLoaderData loadAD = new PlayerLoaderData("Player1Position.txt");
        PlayerLoaderData loadAD2 = new PlayerLoaderData("Player2Position.txt");

        print(loadAD.position);
        print(loadAD2.position);

        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
