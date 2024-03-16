using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solid : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader myMaterial;
    public Color _color;



    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myMaterial = Shader.Find("Gui/Text Shader");
    }


    void Update()
    {
        ColorSprite();
    }

    void ColorSprite()
    {
        myRenderer.material.shader = myMaterial;
        myRenderer.color = _color;
    }

    public void Finish()
    {
        gameObject.SetActive(false);
    }

}
