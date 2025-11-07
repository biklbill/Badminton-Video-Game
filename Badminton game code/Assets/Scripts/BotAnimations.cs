using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimations : MonoBehaviour
{
    public BotHitShuttle botHitShuttle;
    public BotMovement botMovement;

    public Animator animator;

    private int directionX;
    private int directionY;

    private bool moving;

    void Update()
    {
        moving = botMovement.moving;
        directionX = botMovement.directionX;
        directionY = botMovement.directionY;

        animator.SetBool("Moving", moving);
        animator.SetFloat("Direction x", directionX);
        animator.SetFloat("Direction y", directionY);
        animator.SetBool("Forehand", botHitShuttle.forehand);
        animator.SetBool("Backhand", botHitShuttle.backhand);
    }
}
