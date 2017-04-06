using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollision : MonoBehaviour {

    private Vector3 pos1;
    private Vector3 pos2;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player1")
        {
            Debug.Log("Player1CheckPoint");

            pos1 = this.transform.position;

            PlayerLoaderData ad = new PlayerLoaderData(pos1);

            ad.Save("Player1Position.txt");

        }  

        if (player.gameObject.tag == "Player2")
        {
            Debug.Log("Player2CheckPoint");

            pos1 = this.transform.position;

            PlayerLoaderData ad = new PlayerLoaderData(pos1);

            ad.Save("Player2Position.txt");

        }
    }
}
