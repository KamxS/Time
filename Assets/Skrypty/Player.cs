using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth;
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
            //Physics2D.Raycast(transform.position, transform.position - enemy.transform);
            //Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) - enemy.transform);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
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
