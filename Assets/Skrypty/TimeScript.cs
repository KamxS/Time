using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public sealed class TimeScript : MonoBehaviour
{
    public Image uiFill;
    public Image uiFill2;
    float time = 2f;
    GameObject player;
    WaveSpawner WaveManager;
    public float timeSlow;

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
            if (time > 1)
            {
                time = 1;
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
                time -= Time.deltaTime * timeSlow;
                uiFill.fillAmount = time;
                uiFill2.fillAmount = time;
            }
            else
            {
                time += Time.deltaTime * timeSlow;
                uiFill.fillAmount = time;
                uiFill2.fillAmount = time;
            }
        }

       
    }


}
