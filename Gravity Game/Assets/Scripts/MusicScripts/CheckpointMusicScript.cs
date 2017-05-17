using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMusicScript : MonoBehaviour {


	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.gameObject.tag == "Player1" || player.gameObject.tag == "Player2") {

			if (GameManager.musicSource != null) {
				if (player.gameObject.tag == "Player1") {
					GameManager.musicSource.PlayerACross = true;
					}
				else if (player.gameObject.tag == "Player2") {
					GameManager.musicSource.PlayerBCross = true;
				}   
			}
		}
}
}
