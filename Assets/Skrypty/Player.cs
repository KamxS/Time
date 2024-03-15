using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> enemiesToAttack;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        foreach(GameObject enemy in enemiesToAttack)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, enemy.transform.position - transform.position, 5,12);
            if(hit)
            {
                Debug.Log(hit.transform.name);
            }
            Debug.DrawLine(transform.position, enemy.transform.position);
        }
    }

    public void Die()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            enemiesToAttack.Add(collision.gameObject);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            enemiesToAttack.Remove(collision.gameObject);
        }        
    }
}
