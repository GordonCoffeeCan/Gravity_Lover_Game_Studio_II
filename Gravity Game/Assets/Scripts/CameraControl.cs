using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public float minSize = 7;

    private Camera _camera;
    private float _playerDistance;
    

    private void Awake() {
        _camera = Camera.main;
    }

    // Use this for initialization
    void Start () {
        Debug.Log(_camera.aspect);
	}
	
	// Update is called once per frame
	void Update () {

        player1 = GameObject.FindWithTag("Player1").transform;
        player2 = GameObject.FindWithTag("Player1").transform;

        _playerDistance = Vector3.Distance(player1.position, player2.position);
        _camera.transform.position = new Vector3((player1.position.x + player2.position.x) / 2, (player1.position.y + player2.position.y) / 2, _camera.transform.position.z);
        _camera.orthographicSize = _playerDistance * 0.65f;
        if (_camera.orthographicSize < minSize) {
            _camera.orthographicSize = minSize;
        }
        
    }
}
