using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public TextMeshProUGUI textCombo;
    public TextMeshProUGUI pointsTxt;

    int points = 0;
    float comboMultiplier=1.0f;
    public float timeTillReset = 3;
    float curTime = 0;

    private void Start()
    {
    }

    private void Update()
    {
        textCombo.text = Math.Round(comboMultiplier,1).ToString().Replace(",",".") + "x";
        pointsTxt.text = points.ToString();
        if (curTime > 0)
        {
            curTime -= Time.deltaTime;
        }
        else EndCombo();
    }
    void EndCombo()
    {
        comboMultiplier = 1f;
    }
    public void Kill()
    {
        points += (int)(10 * comboMultiplier);
        comboMultiplier += 0.1f;
        curTime = timeTillReset;
    }
}
