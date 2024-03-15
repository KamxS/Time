using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Player : MonoBehaviour
{
    //public List<GameObject> enemiesToAttack;
    public static bool playerDie;
    private WeaponParent weaponParent;
    void Start()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    void Update()
    {

        //weaponParent.Pointerposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }


        /*
        if(Input.GetMouseButton(0))
        {
            Attack();
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 difference = mousePos - new Vector2(transform.position.x,transform.position.y);
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        */
    }
    /*
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
    */

    public void Die()
    {
        playerDie = true;
        Destroy(gameObject);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*
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
    */
}
