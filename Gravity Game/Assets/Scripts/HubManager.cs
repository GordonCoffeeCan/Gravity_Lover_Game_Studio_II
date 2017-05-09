using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour {
    private Transform _envPivot;

    private Transform _playerPR;
    private Transform _playerJP;

    private List<Transform> levelExit;
    
    private float _rotationSpeed = 2;

    private Animator _envPivotAnim;

    public static List<Animator> doors;

    public enum LevelState {
        Null,
        level01Finished,
        level02And03Finished,
        level04Finished
    }

    public LevelState levelState;

    private void Awake() {
        _playerPR = GameObject.Find("PlayerPersian").transform;
        _playerJP = GameObject.Find("PlayerJapanese").transform;

        _envPivot = GameObject.Find("EnvPivot").transform;
        _envPivotAnim = _envPivot.GetComponent<Animator>();

        for (int i = 0; i < 4; i++) {
            doors.Add(GameObject.Find("Door" + (i + 1) + "Trigger").GetComponent<Animator>());
            levelExit.Add(GameObject.Find("Level" + (i + 1) + "Exit").transform);
        }
    }

    // Use this for initialization
    void Start () {
        if (NewGameData.tutorialLevelDone == true && NewGameData.previousLevelName == "tutorialScene") {
            _playerPR.position = levelExit[0].position;
            _playerJP.position = levelExit[0].position;
        } else if (NewGameData.level02Done == true && NewGameData.previousLevelName == "SpokeOnePrototype") {
            _playerPR.position = levelExit[1].position;
            _playerJP.position = levelExit[1].position;
        } else if (NewGameData.level03Done == true && NewGameData.previousLevelName == "SpokeTwoPrototype") {
            _playerPR.position = levelExit[2].position;
            _playerJP.position = levelExit[2].position;
        } else if (NewGameData.level04Done == true && NewGameData.previousLevelName == "SpokeThreePrototype") {
            _playerPR.position = levelExit[3].position;
            _playerJP.position = levelExit[3].position;
        }
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
