using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Player player;
    public GameObject gameoverUI;
    public GameObject timeScale;
    public GameObject comboScale;
    public GameObject levelScale;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highscoreTxt;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameoverUI.SetActive(false);
    }

    void Update()
    {
        if (Player.playerDie)
        {
                timeScale.SetActive(false);
                comboScale.SetActive(false);
                levelScale.SetActive(false);
            ComboSystem combo = GameObject.FindGameObjectWithTag("Spawn").GetComponent<ComboSystem>();
            if(combo.points > PlayerPrefs.GetInt("Highscore",0))
            {
                PlayerPrefs.SetInt("Highscore", combo.points);
            }
            scoreTxt.text = "Your Score is: " + combo.points.ToString();
            highscoreTxt.text = "Your HighScore is: " + PlayerPrefs.GetInt("Highscore",0);
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
