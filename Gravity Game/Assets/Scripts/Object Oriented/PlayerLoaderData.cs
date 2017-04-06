using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlayerLoaderData{

    public Vector3 position;

    private const string POS_X = "xpos";
    private const string POS_Y = "ypos";
    private const string POS_Z = "zpos";

    public PlayerLoaderData(string fileName)
    {
        JSONNode jason = UtilScript.ReadJSONFromFile(Application.dataPath, fileName);

        position = new Vector3(
            jason[POS_X].AsFloat,
            jason[POS_Y].AsFloat,
            jason[POS_Z].AsFloat);

 
    }

    public PlayerLoaderData(Vector3 position)
    {
        this.position = position;
      
    }

    public JSONClass ToJSON()
    {
        JSONClass json = new JSONClass();

        json[POS_X].AsFloat = position.x;
        json[POS_Y].AsFloat = position.y;
        json[POS_Z].AsFloat = position.z;


        return json;
    }

    public void Save(string fileName)
    {
        JSONClass json = ToJSON();

        UtilScript.WriteJSONtoFile(Application.dataPath, fileName, json);
    }

}
