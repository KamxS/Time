using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKatana : MonoBehaviour
{
    public List<GameObject> enemiesToAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Attack();
        }   
    }
    void Attack()
    {
        List<GameObject> hits = new List<GameObject>();
        foreach(GameObject enemy in enemiesToAttack)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, enemy.transform.position - transform.position, 5,~LayerMask.GetMask("Player"));
            if (hit.transform.name == enemy.name)
            {
                hits.Add(enemy); 
            }
        }
        hits.ForEach(hit => hit.GetComponent<Enemy>().Damage());
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
