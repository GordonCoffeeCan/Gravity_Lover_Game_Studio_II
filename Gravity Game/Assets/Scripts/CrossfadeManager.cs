using UnityEngine;
using System.Collections;

public class CrossfadeManager : MonoBehaviour
{
	public AudioClip[] tracks;

	public float fadeTime = 1.0f;

	private int currentTrack = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			currentTrack = 0;
		
				CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			currentTrack = 1;

			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			currentTrack = 2;

			CrossfadeScript.Crossfade(tracks[currentTrack], fadeTime);
		}
	}
}
