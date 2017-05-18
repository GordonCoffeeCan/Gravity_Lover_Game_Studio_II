using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour {
    public bool tutorialLevelDone = false;
    public bool level02Done = false;
    public bool level03Done = false;
    public bool level04Done = false;

    private Transform _envPivot;

    private Transform _playerPR;
    private Transform _playerJP;

    private List<Transform> levelExit;
    
    private float _rotationSpeed = 2;

    public static GameObject _level02Portal;
    public static GameObject _level03Portal;
    public static GameObject _level04Portal;

    public static List<Animator> doors;

    public enum LevelState {
        Null,
        level01Finished,
        level02And03Finished,
        level04Finished
    }

    public static LevelState levelState;

    private void Awake() {
        
    }

    // Use this for initialization
    void Start () {
        _playerPR = GameObject.Find("PlayerPersian").transform;
        _playerJP = GameObject.Find("PlayerJapanese").transform;

        _level02Portal = GameObject.Find("HubLevel2Portal");
        _level03Portal = GameObject.Find("HubLevel3Portal");
        _level04Portal = GameObject.Find("HubLevel4Portal");

        _envPivot = GameObject.Find("EnvPivot").transform;

        levelExit = new List<Transform>();
        doors = new List<Animator>();

        for (int i = 0; i < 4; i++) {
            doors.Add(GameObject.Find("HubLevelDoor" + (i + 1)).GetComponent<Animator>());
            levelExit.Add(GameObject.Find("Level" + (i + 1) + "Exit").transform);
        }

        if (NewGameData.tutorialLevelDone == true && NewGameData.previousLevelName == "tutorialScene") {
            _playerPR.position = levelExit[0].position;
            _playerJP.position = levelExit[0].position;
        } else if (NewGameData.level02Done == true && NewGameData.previousLevelName == "SpokeOnePrototype") {
            _playerPR.position = levelExit[1].position;
            _playerJP.position = levelExit[1].position;
            if(NewGameData.level03Done == false) {
                doors[2].SetBool("Open", true);
            }
        } else if (NewGameData.level03Done == true && NewGameData.previousLevelName == "SpokeTwoPrototype") {
            _playerPR.position = levelExit[2].position;
            _playerJP.position = levelExit[2].position;
            if (NewGameData.level02Done == false) {
                doors[1].SetBool("Open", true);
            }
        } else if (NewGameData.level04Done == true && NewGameData.previousLevelName == "SpokeThreePrototype") {
            _playerPR.position = levelExit[3].position;
            _playerJP.position = levelExit[3].position;
        }

        _level02Portal.SetActive(false);
        _level03Portal.SetActive(false);
        _level04Portal.SetActive(false);

        _envPivot.rotation = NewGameData.currentEnvPivotAngle;
    }
	
	// Update is called once per frame
	void Update () {

        NewGameData.tutorialLevelDone = tutorialLevelDone;
        NewGameData.level02Done = level02Done;
        NewGameData.level03Done = level03Done;
        NewGameData.level04Done = level04Done;

        switch (levelState) {
            case LevelState.level01Finished:
                if(_envPivot.rotation.eulerAngles.z < 90) {
                    _envPivot.rotation = Quaternion.RotateTowards(_envPivot.rotation, Quaternion.Euler(0, 0, 90), 10 * Time.deltaTime);
                }
                break;
            case LevelState.level02And03Finished:
                if (_envPivot.rotation.eulerAngles.z >= 90 && _envPivot.rotation.eulerAngles.z < 180) {
                    _envPivot.rotation = Quaternion.RotateTowards(_envPivot.rotation, Quaternion.Euler(0, 0, 180), 10 * Time.deltaTime);
                }
                break;
            case LevelState.level04Finished:
                
                break;
            default:
                break;
        }

        NewGameData.currentEnvPivotAngle = _envPivot.rotation;

    }
}
