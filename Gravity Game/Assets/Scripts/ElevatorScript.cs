using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

    private float _yPosition;
    private float _originalY;
    public float _elevatorHeight;

	// Use this for initialization
	void Start () {

        _originalY = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {


        _yPosition = _originalY + Mathf.PingPong(Time.time, _elevatorHeight);

        transform.position = new Vector3( transform.position.x,_yPosition, transform.position.z);
    }

}

