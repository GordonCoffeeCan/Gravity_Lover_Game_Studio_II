using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour {

    public Transform self;
    public Transform other;
    private float distance;

    public float range; //how close the objects need to be to each other to gravity shift;
    public float minRange; //how close the players will stop moving toward from each other;

    public Light glow;

    public static bool inShiftRange = false;

    public static Vector3 middlePoint;

    private string _tag;
    public Rigidbody2D rb;

    private void Awake() {
        
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(self.position, other.position);
        middlePoint = (self.position - other.position) / 2;
        inRange();
	}

    void inRange()
    {
        if (distance <= range)
        {
            glow.enabled = true;
            inShiftRange = true;
        }
        else
        {
            glow.enabled = false;
            inShiftRange = false;
        }

    }
}
