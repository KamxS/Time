using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Player : MonoBehaviour
{
    //public List<GameObject> enemiesToAttack;
    public ParticleSystem deathParticle;
    public static bool playerDie;
    private WeaponParent weaponParent;
    void Start()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    void Update()
    {
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        if (direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Die()
    {
        playerDie = true;
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
