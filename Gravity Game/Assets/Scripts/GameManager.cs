using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Transform finalEffect;
    private bool particleisThere = false;

    public static MixerScript musicSource;

    private void Awake() {
        if (musicSource == null) {
            musicSource = GameObject.Find("MusicSource").GetComponent<MixerScript>();
        } else {
            MixerScript[] _musicSources = FindObjectsOfType(typeof(MixerScript)) as MixerScript[];
            _musicSources[1].gameObject.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
        musicSource.GetComponent<AudioSource>().Play();
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
