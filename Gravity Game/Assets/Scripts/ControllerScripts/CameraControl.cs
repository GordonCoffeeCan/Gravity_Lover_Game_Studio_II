using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour {

    private Transform player1;
    private Transform player2;
    public float minSize = 15;

    private Camera _camera;
    private float _playerDistance;

    private float _currentCamSize;

    private void Awake() {
        _camera = Camera.main;
    }

    // Use this for initialization
    void Start () {
        player1 = GameObject.FindWithTag("Player1").transform;
        player2 = GameObject.FindWithTag("Player2").transform;
    }
	
	// Update is called once per frame
	void Update () {

        if (NewGameData.player1isDead == false && NewGameData.player2isDead == false) {
            _currentCamSize = _camera.orthographicSize;
            _playerDistance = Vector3.Distance(player1.position, player2.position);
            _camera.transform.position = new Vector3((player1.position.x + player2.position.x) / 2, (player1.position.y + player2.position.y) / 2, _camera.transform.position.z);
            _camera.orthographicSize = _playerDistance * 0.65f;
        } else {
            _camera.orthographicSize = _currentCamSize;
        }
        

        if (SceneManager.GetActiveScene().name == "HubScene") {
            minSize = 20;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 20, 46);
        } else if(SceneManager.GetActiveScene().name != "HubScene") {
            minSize = 15;
        }

        if (_camera.orthographicSize < minSize) {
            _camera.orthographicSize = minSize;
        }
    }
}
