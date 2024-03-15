using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootenemy : MonoBehaviour
{
    public Transform player;
    public GameObject bullet;
    public float shootCooldown;
    public float startShootCooldown;


    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = startShootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = direction;

        if (shootCooldown <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootCooldown = startShootCooldown;
        }
        else
            shootCooldown -= Time.deltaTime;

    }
}
