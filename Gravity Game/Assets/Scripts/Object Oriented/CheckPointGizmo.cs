using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointGizmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos() {
        Gizmos.DrawIcon(this.transform.position, "checkpointIcon.png", true);
    }
}