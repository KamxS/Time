using NUnit.Framework;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTime4 : MonoBehaviour
{
    public AIPath aiPath;
    public float starSpeed;
    public bool isSlowed;


    private void Start()
    {
        starSpeed = aiPath.maxSpeed;
    }

    void Update()
    {
        if (TimeScript.slowTime)
        {
            if(!isSlowed)
            {
                aiPath.maxSpeed /= 2f;
                isSlowed = true;
            }

        }
        else if(!TimeScript.slowTime)
        {
            aiPath.maxSpeed = starSpeed;
            isSlowed = false;
        }

    }


    void SlowEnemy()
    {
        aiPath.maxSpeed /= 2f;
    }

}
