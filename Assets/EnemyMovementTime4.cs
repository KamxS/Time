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
        if (Time.slowTime)
        {
            if(!isSlowed)
            {
                aiPath.maxSpeed /= 2f;
                isSlowed = true;
                Debug.Log("Slow");
            }

        }
        else if(!Time.slowTime)
        {
            aiPath.maxSpeed = starSpeed;
            isSlowed = false;
            Debug.Log("NoSlow");
        }

    }


    void SlowEnemy()
    {
        aiPath.maxSpeed /= 2f;
    }

}
