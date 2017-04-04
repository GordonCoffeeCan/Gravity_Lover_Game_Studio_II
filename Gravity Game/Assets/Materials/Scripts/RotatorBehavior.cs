using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorBehavior : MonoBehaviour {
    public float rotateSpeed = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
	}
}
