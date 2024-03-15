using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public sealed class TimeScript : MonoBehaviour
{
    public Image uiFill;
    public float time = 1f;
    public float loseTimeFloat = 1f;
    GameObject player;

    public static bool slowTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if(!Pauze.PauseActive)
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
            }
            else
            {
                time += 0.0005f;
                uiFill.fillAmount = time;
            }
        }

       
    }


}
