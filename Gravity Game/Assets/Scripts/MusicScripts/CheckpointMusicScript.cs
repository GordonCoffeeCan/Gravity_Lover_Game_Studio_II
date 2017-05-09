using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMusicScript : MonoBehaviour {


	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.gameObject.tag == "Player1" || player.gameObject.tag == "Player2")
		{
			if (player.gameObject.tag == "Player1") 
			{
				GameObject.Find ("MusicSource").GetComponent<MixerScript> ().PlayerACross = true;
			}
			else
				GameObject.Find ("MusicSource").GetComponent<MixerScript> ().PlayerBCross = true;

		} 
	}
}
