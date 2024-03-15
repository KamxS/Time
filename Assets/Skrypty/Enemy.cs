using System.Collections;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;
using System;

public sealed class Enemy : MonoBehaviour
{
    GameObject player;
    AIPath ai;
    Rigidbody2D rb;
    bool canDash = true;
    bool dashing = false;
    bool playerInRange = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GetComponent<AIPath>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && !dashing)
        {
            Attack();
        }

        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float dist = Vector2.Distance(playerPos, transform.position);
        /*
        float dashDistance = 5f;
        if(dist < dashDistance && canDash)
        {
            int v = Random.Range(0, 3);
            if (v ==0)
            {
                StartCoroutine(Dash());
            }        
        }else if(dist>=dashDistance && !canDash)
        {
            canDash = true;
        }
        */
    }
    void Attack()
    {
        player.GetComponent<Player>().Die();
    }

    private void FixedUpdate()
    {
        
    }
    private IEnumerator Dash()
    {
        dashing = true;
        canDash = false;
        ai.canMove = false;
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1);
        Vector2 dashDir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        rb.velocity = dashDir * 10f;
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector2(0,0);
        ai.canMove = true;
        dashing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !dashing)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void Damage()
    {
        Destroy(gameObject);
    }
}
