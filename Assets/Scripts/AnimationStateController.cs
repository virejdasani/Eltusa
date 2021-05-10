using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles all the animation transitions
// From: https://www.youtube.com/watch?v=FF6kezDQZ7s

public class AnimationStateController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        bool isJumping = animator.GetBool("isJumping");

        bool verticalPressed = Input.GetButton("Vertical");
        bool runningPressed = Input.GetKey(KeyCode.LeftShift) && isWalking;
        bool jumpPressed = Input.GetButton("Jump");

// For Walking
        // If (w, s, up or down) is pressed, the isWalking animation is set to true so walking animation is played
        if (!isWalking && verticalPressed)
        {
            animator.SetBool("isWalking", true);
        }

        // If (w, s, up or down) is not being pressed, the isWalking animation is set to false so walking animation is stopped and goes back to idle
        if (isWalking && !verticalPressed)
        {
            animator.SetBool("isWalking", false);
        }

// For Running
        // If walking and shift is pressed, isRunning is true
        if (!isRunning && runningPressed)
        {
            animator.SetBool("isRunning", true);
        }

        if (isRunning && !runningPressed)
        {
            animator.SetBool("isRunning", false);
        }

// For Jumping
        if (!isJumping && jumpPressed)
        {
            animator.SetBool("isJumping", true);
        }

        if (!jumpPressed && isJumping)
        {
            animator.SetBool("isJumping", false);
        }

    }
}
