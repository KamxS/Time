using System.Collections;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;
using System;

public class Enemy : MonoBehaviour
{
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if(direction.x<0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }else 
            gameObject.transform.localScale = new Vector3(1,1,1);
    }

    public void Damage()
    {
        Destroy(gameObject);
    }
}
