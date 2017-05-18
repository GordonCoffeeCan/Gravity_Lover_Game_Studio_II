using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerReset : MonoBehaviour {
    public AudioMixerSnapshot Music1;
    // Use this for initialization
    void Start() {
        Music1.TransitionTo(0f);
    }

}
