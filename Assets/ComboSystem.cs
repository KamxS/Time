using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public int kills= 0;
    float comboMultiplier=1.0f;

    private void Update()
    {
        if(comboMultiplier>0)
        {
        }
    }
    public void Kill()
    {
        StopCoroutine(EndCombo());
        kills += 1;
        comboMultiplier *= 1.2f;
        Debug.Log("Combo: " + comboMultiplier);
    }

    IEnumerator EndCombo()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Combo Done");
        comboMultiplier = 0;
    }
}
