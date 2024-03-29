using System.Collections;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;
using System;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathParticle;
    WaveSpawner manager;
    ComboSystem comboSystem;
    Transform player;
    void Start()
    {
        gameObject.GetComponent<shootenemy>().enabled = false;
        gameObject.GetComponent<AIPath>().canMove = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.GetComponent<AIDestinationSetter>().target = player;
        manager = GameObject.FindGameObjectWithTag("Spawn").GetComponent<WaveSpawner>();
        comboSystem= GameObject.FindGameObjectWithTag("Spawn").GetComponent<ComboSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if(direction.x<0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }else
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
    }
    public void TurnOn()
    {
        gameObject.GetComponent<AIPath>().canMove = true;
        gameObject.GetComponent<shootenemy>().enabled = true;
    }

    public void Damage()
    {
        SoundManager2.Instance.PlaySFX("kill");
        manager.kills += 1;
        comboSystem.Kill();
        gameObject.GetComponent<shootenemy>().enabled = false;
        gameObject.GetComponent<AIPath>().canMove = false;
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
