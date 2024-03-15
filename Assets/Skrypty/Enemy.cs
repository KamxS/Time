using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public sealed class Enemy : MonoBehaviour
{
    GameObject player;
    AIPath ai;
    public bool canDash = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float dist = Vector2.Distance(playerPos, transform.position);
        Debug.Log(dist);
        float dashDistance = 5f;
        if(dist < dashDistance && canDash)
        {
            StartCoroutine(Dash());
        }else if(dist>=dashDistance)
        {
            canDash = true;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        ai.canMove = false;
        yield return new WaitForSeconds(3);
        ai.canMove = true;
    }

    public void Damage()
    {
        Destroy(gameObject);
    }
}
