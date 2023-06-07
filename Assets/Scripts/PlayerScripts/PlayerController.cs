using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Rigidbody2D rb;

    // Player
    public float walkSpeed = 1f;
    float inputHorizontal;
    float inputVertical;

    // Animations and states
    Animator animator;
    string currentAnimState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    // Sound
    public AudioSource footstepsSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = SimpleInput.GetAxis("Horizontal");
        inputVertical = SimpleInput.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal, inputVertical).normalized * walkSpeed;
        footstepsSound.pitch = 0.65f;


        if (inputHorizontal > 0)
        {
            ChangeAnimationState(PLAYER_WALK_RIGHT);
            footstepsSound.enabled = true;
        }
        else if (inputHorizontal < 0)
        {
            ChangeAnimationState(PLAYER_WALK_LEFT);
            footstepsSound.enabled = true;
        }
        else if (inputVertical > 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP);
            footstepsSound.enabled = true;
        }
        else if (inputVertical < 0)
        {
            ChangeAnimationState(PLAYER_WALK_DOWN);
            footstepsSound.enabled = true;

        }
        else
        {
            ChangeAnimationState(PLAYER_IDLE);
            footstepsSound.enabled = false;
        }
    }

    // Animation state changer
    void ChangeAnimationState(string newState)
    {
        // Stop animation from interrupting itself
        if (currentAnimState == newState) return;
        // Play new animation
        animator.Play(newState);
        // Update current state
        currentAnimState = newState;
    }

}
