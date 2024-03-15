using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootenemy : MonoBehaviour
{
    Transform player;
    Transform front;
    public GameObject bullet;
    public float shootCooldown;
    public float startShootCooldown;


    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = startShootCooldown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        front = gameObject.transform.Find("Front").transform;
        gameObject.GetComponent<AIDestinationSetter>().target = player;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - front.position.x, player.position.y - front.position.y);
        front.up = direction;

        if (shootCooldown <= 0)
        {
            GameObject bulletInstance = Instantiate(bullet, front.position, front.rotation );
            //bulletInstance.transform.rotation.eulerAngles = new Vector3(0,0,bullett.tra.
            shootCooldown = startShootCooldown;
        }
        else
            shootCooldown -= Time.deltaTime;

    }
}
