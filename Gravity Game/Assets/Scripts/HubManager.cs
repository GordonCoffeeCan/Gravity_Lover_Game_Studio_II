using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour {
    public Transform envPivot;
    private float _rotationSpeed = 2;
    private Animator _envPivotAnim;

    public enum LevelState {
        Null,
        level01Finished,
        level02And03Finished,
        level04Finished
    }

    public LevelState levelState;

    // Use this for initialization
    void Start () {
        _envPivotAnim = envPivot.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (levelState) {
            case LevelState.level01Finished:
                _envPivotAnim.SetBool("ToLevel02and03", true);
                Debug.Log("level01Finished");
                break;
            case LevelState.level02And03Finished:
                _envPivotAnim.SetBool("ToLevel04", true);
                Debug.Log("level02And03Finished");
                break;
            case LevelState.level04Finished:
                
                Debug.Log("level04Finished");
                break;
            default:
                break;
        }
	}
}
