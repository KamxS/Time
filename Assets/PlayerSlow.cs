using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{
    public float startSpeed;
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
        if (Time.slowTime)
        {
            if(!isSlowed)
            {
                movement.speed/= 2f;
                isSlowed = true;
            }

        }
        else if(!Time.slowTime)
        {
            movement.speed = startSpeed;
            isSlowed = false;
        }
    }
}
