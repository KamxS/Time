using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{
    float startSpeed;
    public bool isSlowed;
    Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
        startSpeed = movement.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeScript.slowTime && !isSlowed)
        {
            movement.speed/= 2f;
            isSlowed = true;
        }
        else if(!TimeScript.slowTime && isSlowed)
        {
            movement.speed = startSpeed;
            isSlowed = false;
        }
    }
}
