using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour {

    public Transform self;
    public Transform other;
    float distance;

    public float range; //how close the objects need to be to each other to gravity shift

    public Light glow;

    private bool canShift = false;

    private string _gravityShiftKey;

    private string _tag;
    public Rigidbody2D rb;

    private void Awake() {
        _tag = this.gameObject.tag;
        
    }

    // Use this for initialization
    void Start () {
        //Detect which player is and set control scheme
        if (_tag == "Player1") {
            _gravityShiftKey = "ShiftButton";
        } else if (_tag == "Player2") {
            _gravityShiftKey = "GamePad_Shift";
        }
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(self.position, other.position);
        
        inRange();

        gravityShift();
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
        if (Input.GetButtonUp(_gravityShiftKey))
        {
            if(canShift == true)
            {
                rb.gravityScale *= -1;
            }
        }
    }
}
