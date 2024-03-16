using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour
{

    public static Shadows me;
    public GameObject Sombra;
    public List<GameObject> pool = new List<GameObject>();
    private float cronoimetro;
    public float speed;
    public Color _color;


    private void Awake()
    {
        me = this;
    }

    public GameObject GetShadows()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                pool[i].transform.position = transform.position;
                pool[i].transform.rotation = transform.rotation;
                pool[i].GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                pool[i].GetComponent<solid>()._color = _color;
                return pool[i];
            }
        }
        GameObject obj = Instantiate(Sombra, transform.position, transform.rotation) as GameObject;
        obj.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        obj.GetComponent<solid>()._color = _color;
        pool.Add(obj);
        return(obj);

    }

    public void Sombras_Skill()
    {
        cronoimetro += speed * Time.deltaTime;
        if(cronoimetro > 1)
        {
            GetShadows();
            cronoimetro = 0;
        }
    }


}
