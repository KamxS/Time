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

        if (TimeScript.slowTime && light2d.pointLightOuterRadius > 20)
        {
            light2d.pointLightOuterRadius -= 0.1f;
            isSlowed = true;
        }
        else if (!TimeScript.slowTime && light2d.pointLightOuterRadius < 40)
        {
            
            isSlowed = false;
            light2d.pointLightOuterRadius += 0.1f;
        }


    }
}
