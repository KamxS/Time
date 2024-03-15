using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public sealed class Time : MonoBehaviour
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

        if(time > 1f)
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
            slowTime = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            slowTime = false;
        }

        if(slowTime)
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


    void loseTime(float loseTimeFloat)
    {
        time -= 0.5f;
        uiFill.fillAmount = time;
    }

   void GainTime(float loseTimeFloat)
   {
        time += 0.5f;
        uiFill.fillAmount = time;
    }



}
