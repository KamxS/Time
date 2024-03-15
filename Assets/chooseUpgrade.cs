using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class chooseUpgrade : MonoBehaviour
{

    public WaveSpawner waveSpawner;

    void Start()
    {
       waveSpawner = GameObject.FindGameObjectWithTag("Spawn").GetComponent<WaveSpawner>();
    }

    public void OnMouseDown()
    {
        waveSpawner.ChooseUpgrade();
        Debug.Log("Choose");
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            waveSpawner.ChooseUpgrade();
            Debug.Log("Choose");
        }
    }

}
