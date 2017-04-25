using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthoCameraController : MonoBehaviour {

    public float GetFieldOfView(float orthoSize, float distanceFromOrigin)
    {
        // orthoSize
        float a = orthoSize;
        // distanceFromOrigin
        float b = Mathf.Abs(distanceFromOrigin);

        float fieldOfView = Mathf.Atan(a / b) * Mathf.Rad2Deg * 2f;
        return fieldOfView;


    }


}
