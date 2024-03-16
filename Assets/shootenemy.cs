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
    public int recoil;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = startShootCooldown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        front = gameObject.transform.Find("Front").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - front.position.x, player.position.y - front.position.y);
        front.up = direction;

        if (shootCooldown <= 0)
        {
            Quaternion bulletRotation = front.rotation;
            if(recoil > 0)
            {
                int randRot = Random.Range(-recoil, recoil);
                bulletRotation *= Quaternion.Euler(0, 0, randRot);
            }
            Instantiate(bullet, front.position, bulletRotation);
            shootCooldown = startShootCooldown;
        }
        else
            shootCooldown -= Time.deltaTime;

    }
}
