using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoClip[] videoList;

    private int _currentClipIndex = 0;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;

    private void Awake() {
        if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == true) {
            _currentClipIndex = 1;
        }

        if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == true && NewGameData.level03Done == true) {
            _currentClipIndex = 2;
        }

        if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == true && NewGameData.level03Done == true && NewGameData.level04Done == true) {
            _currentClipIndex = 3;
        }

        _videoPlayer = this.GetComponent<VideoPlayer>();
        _audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        _videoPlayer.source = VideoSource.VideoClip;

        _videoPlayer.clip = videoList[_currentClipIndex];

        _videoPlayer.EnableAudioTrack(0, true);
        _videoPlayer.SetTargetAudioSource(0, _audioSource);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(_videoPlayer.isPlaying);
    }


}
