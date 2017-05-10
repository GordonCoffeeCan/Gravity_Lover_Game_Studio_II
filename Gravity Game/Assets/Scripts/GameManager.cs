using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Transform finalEffect;
    private bool particleisThere = false;

    public static MixerScript musicSource;

    // Use this for initialization
    void Start () {
        musicSource = GameObject.Find("MusicSource").GetComponent<MixerScript>();

    }
	
	// Update is called once per frame
	void Update () {
        if (GameData.isWin == true) {
            if (particleisThere == false) {
                Instantiate(finalEffect, Vector3.zero, Quaternion.identity);
                particleisThere = true;
            }
        }
    }
}
