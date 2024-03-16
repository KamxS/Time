using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeele : MonoBehaviour
{
    Transform spear;
    Transform player;
    private void Start()
    {
        spear = transform.Find("Hand");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        spear.right = direction;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance<2f)
        {
        }
    }
}
