using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public TextMeshProUGUI textCombo;
    public int kills= 0;
    float comboMultiplier=1.0f;
    public float timeTillReset = 3;
    float curTime = 0;

    private void Start()
    {
    }

    private void Update()
    {
        textCombo.text = comboMultiplier.ToString().Replace(",",".") + "x";
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
        kills += 1;
        comboMultiplier += 0.1f;
        curTime = timeTillReset;
    }
}
