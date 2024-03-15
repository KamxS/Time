using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 dir;
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dir.x * speed, dir.y*speed);
    }
}
