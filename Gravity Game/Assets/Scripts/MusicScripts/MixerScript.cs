using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerScript : MonoBehaviour {
	public AudioMixerSnapshot Music1;
	public AudioMixerSnapshot Music2;
	public AudioMixerSnapshot Music3;
	public AudioMixerSnapshot FadeToBlack;
	public AudioSource MainTheme;
	public AudioSource PlayerATheme;
	public AudioSource PlayerBTheme;
	public bool PlayerACross;
	public bool PlayerBCross;
	public bool blackFade;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (PlayerACross)
		{
          //  if (PlayerACross == true && PlayerBCross == false) {


                PlayerACross = false;
                PlayerBCross = false;
                PlayerATheme.Play();
                Music2.TransitionTo(1f);
                StartCoroutine(WaitTimeA());
          //  }
		}

        if (PlayerBCross) {
           // if (PlayerACross == false && PlayerBCross == true) {
                PlayerBCross = false;
                PlayerACross = false;
                PlayerBTheme.Play();
                Music3.TransitionTo(1f);
                StartCoroutine(WaitTimeB());
          //  }
        }

		if (blackFade) 
		{
			Debug.Log ("fade to black");
			PlayerBCross = false;
			PlayerACross = false;
			FadeToBlack.TransitionTo (1f);
		}
			
	}

	IEnumerator WaitTimeA ()
	{
		int wait_time = Random.Range (10,15);
		yield return new WaitForSeconds (wait_time);
		Music1.TransitionTo (1f);
	}

	IEnumerator WaitTimeB ()
	{
		int wait_time = Random.Range (10,15);
		yield return new WaitForSeconds (wait_time);
		Music1.TransitionTo (1f);
	}
	}
