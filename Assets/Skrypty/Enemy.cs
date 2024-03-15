using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public sealed class Enemy : MonoBehaviour
{
    GameObject player;

    AIDestinationSetter ai;
    [SerializeField] GameObject bullet;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GetComponent<AIDestinationSetter>();
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
        if(dist < 5f)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        ai.target = null;
        yield return new WaitForSeconds(1);
        ai.target = player.transform;
    }

    public void Damage()
    {
        Destroy(gameObject);
    }
}
