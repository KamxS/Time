using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject Player;

    GameObject Front;
    [SerializeField] GameObject bullet;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Front = GameObject.Find("Front");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //Vector2 playerDistance = Vector2.Distance(Player.transform.position, transform.position;
    }
}
