using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKatana : MonoBehaviour
{
    public List<GameObject> enemiesToAttack;
    public int katanaSize = 1;
    public GameObject cameratoshake;

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
            SoundManager2.Instance.PlaySFX("atak");
        }   
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 difference = mousePos - new Vector2(transform.position.x,transform.position.y);
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
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
    public void IncreaseKatana()
    {
        WeaponParent weapon = transform.parent.Find("WeaponParent").GetComponent<WeaponParent>();
        if (weapon.katanaSize < 2f) weapon.katanaSize += 0.1f;
        GetComponent<BoxCollider2D>().offset += new Vector2(0.05f, 0f);
        GetComponent<BoxCollider2D>().size += new Vector2(0.1f,0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            enemiesToAttack.Add(collision.gameObject);
            RandomSake();
        } 
    }

    public void RandomSake()
    {
        int randomnumber = Random.Range(0, 3);
        {
            if (randomnumber == 0)
            {
                cameratoshake.GetComponent<Animator>().SetTrigger("shake1");
            }
            if (randomnumber == 1)
            {
                cameratoshake.GetComponent<Animator>().SetTrigger("shake2");
            }
            if (randomnumber == 2)
            {
                cameratoshake.GetComponent<Animator>().SetTrigger("shake3");
            }
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
