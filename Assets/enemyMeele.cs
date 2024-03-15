using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeele : MonoBehaviour
{
    public bool playerIn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") playerIn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") playerIn = false;
    }

}
