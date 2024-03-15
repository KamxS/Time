using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Player player;
    public GameObject gameoverUI;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameoverUI.SetActive(false);
    }

    void Update()
    {
        if (Player.playerDie)
        {

            gameoverUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Player.playerDie = false;
                TimeScript.slowTime = false;
            }
        }
    }
}
