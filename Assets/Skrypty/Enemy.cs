using System.Collections;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;
using System;

public class Enemy : MonoBehaviour
{
    GameObject player;
    SpriteRenderer sprite;
    AIPath ai;
    Rigidbody2D rb;
    bool canDash = true;
    void Start()
    {
        ai = GetComponent<AIPath>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<AIDestinationSetter>().target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float dist = Vector2.Distance(playerPos, transform.position);
        Debug.Log(dist);
        float dashDistance = 5f;
        if(dist < dashDistance && canDash)
        {
            StartCoroutine(Dash());
        }else if(dist>=dashDistance && !canDash)
        {
            canDash = true;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        ai.canMove = false;
        //rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1);
        Vector2 dashDir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        rb.velocity = dashDir * 10f;
        yield return new WaitForSeconds(2);
        //rb.velocity = new Vector2(0,0);
        ai.canMove = true;
    }

    public void Damage()
    {
        Destroy(gameObject);
    }
}
