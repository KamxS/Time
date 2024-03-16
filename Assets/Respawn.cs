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
            ComboSystem combo = GameObject.FindGameObjectWithTag("Spawn").GetComponent<ComboSystem>();
            if(combo.points > PlayerPrefs.GetInt("Highscore",0))
            {
                PlayerPrefs.SetInt("Highscore", combo.points);
            }
            Debug.Log("Score: " + combo.points);
            Debug.Log("HighScore: " + PlayerPrefs.GetInt("Highscore",0));
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
