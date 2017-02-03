using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityTrigger : MonoBehaviour {

    public Transform self;
    public Transform other;
    float distance;

    public float range; //how close the objects need to be to each other to gravity shift

    public Light glow;

    private bool canShift = false;

    public KeyCode shiftButton = KeyCode.LeftShift;


    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(self.position, other.position);
        

        inRange();


       
	}

    void inRange()
    {
        if (distance <= range)
        {
            glow.enabled = true;
            canShift = true;
        }
        else
        {
            glow.enabled = false;
            canShift = false;
        }

    }

    void gravityShift()
    {
        if (Input.GetKeyDown(shiftButton))
        {
            if(canShift == true)
            {
                rb.gravityScale *= -1;
            }
        }
    }
}
