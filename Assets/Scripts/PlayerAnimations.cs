using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public PlayerHitShuttle playerHitShuttle;

    public Animator animator;

    private int directionX;
    private int directionY;

    private bool moving;

    void Update()
    {
        moving = false;
        directionX = 0;
        directionY = 0;

        if (Input.GetKey(KeyCode.W))
        {
            directionY = 1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            directionY = -1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionX = -1;
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            directionX = 1;
            moving = true;
        }

        animator.SetBool("Moving", moving);
        animator.SetFloat("Direction x", directionX);
        animator.SetFloat("Direction y", directionY);
        animator.SetBool("Forehand", playerHitShuttle.forehand);
        animator.SetBool("Backhand", playerHitShuttle.backhand);
    }
}
