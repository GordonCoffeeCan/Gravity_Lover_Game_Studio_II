using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {

    public VideoClip[] videoList;

    private int _currentClipIndex = 0;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;

    private void Awake() {
        if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == true) {
            _currentClipIndex = 1;
        }else if (NewGameData.tutorialLevelDone == true && NewGameData.level03Done == true) {
            _currentClipIndex = 1;
        }

        if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == true && NewGameData.level03Done == true) {
            _currentClipIndex = 2;
        }

        if (NewGameData.tutorialLevelDone == true && NewGameData.level02Done == true && NewGameData.level03Done == true && NewGameData.level04Done == true) {
            _currentClipIndex = 3;
        }

        _videoPlayer = this.GetComponent<VideoPlayer>();
        _audioSource = this.GetComponent<AudioSource>();

        _videoPlayer.source = VideoSource.VideoClip;

        _videoPlayer.clip = videoList[_currentClipIndex];
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!_videoPlayer.isPlaying || Input.GetKeyDown(KeyCode.Escape)) {
            Invoke("Loadcene", 0.8f);
        }
    }

    private void Loadcene() {
        _audioSource.clip = null;
        switch (_currentClipIndex) {
            case 0:
                SceneManager.LoadScene("tutorialScene");
                break;
            case 1:
                SceneManager.LoadScene("HubScene");
                break;
            case 2:
                SceneManager.LoadScene("HubScene");
                break;
            case 3:
                SceneManager.LoadScene("thankYouScene");
                break;
        }
    }


}
