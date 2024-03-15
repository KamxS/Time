using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Player player;
    //public AIPath aiPath;
    public float starSpeed;
    public bool isSlowed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        starSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);


        if (TimeScript.slowTime && !isSlowed)
        {
            speed /= 2f;
            isSlowed = true;
        }
        else if (!TimeScript.slowTime && isSlowed)
        {
            speed = starSpeed;
            isSlowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.Die();
            Destroy(gameObject);
        }
    }


}
