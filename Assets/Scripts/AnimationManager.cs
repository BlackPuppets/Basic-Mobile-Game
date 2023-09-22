using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AnimationManager;

public class AnimationManager : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Play(string animationTrigger)
    {
        animator.Play(animationTrigger);
    }

    public void Play(string animationTrigger, float animationSpeed)
    {
        animator.speed = animationSpeed;
        animator.Play(animationTrigger);
    }
}
