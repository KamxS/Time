using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour
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

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 difference = mousePos - new Vector2(transform.position.x,transform.position.y);
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
    }
    void Attack()
    {
        List<GameObject> hits = new List<GameObject>();
        foreach(GameObject enemy in enemiesToAttack)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, enemy.transform.position - transform.position, 5,~LayerMask.GetMask("Player"));
            if (hit.collider== enemy.GetComponent<Collider2D>())
            {
                hits.Add(enemy); 
            }
        }
        hits.ForEach(hit => hit.GetComponent<Enemy>().Damage());
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
