using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public sealed class TimeScript : MonoBehaviour
{
    public Image uiFill;
    public Image uiFill2;
    public float time = 1f;
    public float loseTimeFloat = 1f;
    GameObject player;
    WaveSpawner WaveManager;

    public static bool slowTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        WaveManager = GameObject.FindGameObjectWithTag("Spawn").GetComponent<WaveSpawner>();
    }

    private void Update()
    {

        if(!Pauze.PauseActive && !WaveManager.choosingUpgrade)
        {
            if (time > 1f)
            {
                time = 1f;
            }

            if (time <= 0f)
            {
                time = 0f;
                player.GetComponent<Player>().Die();
            }


            if (Input.GetMouseButtonDown(1))
            {
                slowTime = !slowTime;
            }

            if (slowTime)
            {
                time -= 0.0005f;
                uiFill.fillAmount = time;
                uiFill2.fillAmount = time;
            }
            else
            {
                time += 0.0005f;
                uiFill.fillAmount = time;
                uiFill2.fillAmount = time;
            }
        }

       
    }


}
