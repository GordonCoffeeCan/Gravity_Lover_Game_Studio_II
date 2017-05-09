using UnityEngine;
using DG.Tweening;
using System.Collections;
using Beat;

public class MusicSourceTest : MonoBehaviour
{
	public bool GOTIME;
	public bool PlayerACross;
	public bool PlayerBCross;
	public bool CrossfadeBack;

	public AudioClip loop1;
	public AudioClip loop2;
	public AudioClip loop3;


	public MusicSource MyMusicSource;

	void Start ()
	{
		GOTIME = true;
	}
	void Update()
	{
		if (GOTIME)
		{
			MyMusicSource.LoopAt(loop1, Clock.Instance.AtNextMeasure());
		}

		if (PlayerACross)
		{
			PlayerACross = false;
			PlayerBCross = false;
			GOTIME = false;
			StartCoroutine (WaitTimeA ());
			MyMusicSource.CrossfadeToLoop(loop2, Clock.Instance.AtNextMeasure(), Clock.Instance.MeasureLengthD());
		}

		if (PlayerBCross)
		{
			PlayerBCross = false;
			PlayerACross = false;
			GOTIME = false;
			StartCoroutine (WaitTimeB ());
			MyMusicSource.CrossfadeToLoop(loop3, Clock.Instance.AtNextMeasure(), Clock.Instance.MeasureLengthD());
		}

		if (CrossfadeBack)
		{
			CrossfadeBack = false;
			MyMusicSource.CrossfadeToLoop(loop1, Clock.Instance.AtNextMeasure(), Clock.Instance.BeatLengthD());
		}
	}

	IEnumerator WaitTimeA ()
	{
		int wait_time = Random.Range (18,28);
		yield return new WaitForSeconds (wait_time);
		CrossfadeBack = true;
	}

	IEnumerator WaitTimeB ()
	{
		int wait_time = Random.Range (18,28);
		yield return new WaitForSeconds (wait_time);
		CrossfadeBack = true;
	}

}
