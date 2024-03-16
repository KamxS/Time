using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightinSlowMo : MonoBehaviour
{
    public bool isSlowed;
    public Light2D light2d;
    public GameObject cameraobject;

    void Update()
    {

        if (TimeScript.slowTime && light2d.pointLightOuterRadius > 12 || TimeScript.slowTime && cameraobject.GetComponent<Camera>().orthographicSize > 5f)
        {
            light2d.pointLightOuterRadius -= 0.1f;
            cameraobject.GetComponent<Camera>().orthographicSize -= 0.01f;
            isSlowed = true;
        }
        else if (!TimeScript.slowTime && light2d.pointLightOuterRadius < 19 || TimeScript.slowTime && cameraobject.GetComponent<Camera>().orthographicSize < 5.5f)
        {           
            isSlowed = false;
            light2d.pointLightOuterRadius += 0.1f;
            cameraobject.GetComponent<Camera>().orthographicSize += 0.01f;
        }


    }
}
