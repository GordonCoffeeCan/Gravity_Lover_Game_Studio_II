using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLoader : MonoBehaviour {

    public GameObject _player1Prefab;
    public GameObject _player2Prefab;

    public string Player1PosString; //name of the file where player1's checkpoint position is saved
    public string Player2PosString; //name of the file where player2's checkpoint position is saved



    public Vector3 player1Pos;
    public Vector3 player2Pos;
    // Use this for initialization
    void Awake()
    {
        PlayerLoaderData loadAD = new PlayerLoaderData(Player1PosString);
        PlayerLoaderData loadAD2 = new PlayerLoaderData(Player2PosString);

        //print(loadAD.position);
        //print(loadAD2.position);

        player1Pos = loadAD.position;
        player2Pos = loadAD2.position;

        GameObject Player1 = Instantiate(_player1Prefab, player1Pos, transform.rotation);
       
        
        GameObject Player2 = Instantiate(_player2Prefab, player2Pos, transform.rotation);
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}
