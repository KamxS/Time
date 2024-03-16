using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klatanaanimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TriggerAttack();
        }
    }

    void TriggerAttack()
    {
        animator.SetTrigger("Attack");
    }
}
