using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private PlayerManager manager;
    private Animator animator;

    private void Start()
    {
        manager = GetComponentInParent<PlayerManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", manager.AnimVariables.isWalking);
        animator.SetFloat("Horizontal", manager.AnimVariables.horizontal);
        animator.SetFloat("Vertical", manager.AnimVariables.vertical);
    }
}
