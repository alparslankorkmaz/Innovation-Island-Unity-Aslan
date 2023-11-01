using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    string currentAnimState;
    const string NPC_IDLE = "NPC_Idle";
    const string NPC_WALK_LEFT = "NPC_Walk_Left";
    const string NPC_WALK_RIGHT = "NPC_Walk_Right";
    const string NPC_WALK_UP = "NPC_Walk_Up";
    const string NPC_WALK_DOWN = "NPC_Walk_Down";


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f && currentPoint == pointB.transform)
        {
            ChangeAnimationState(NPC_WALK_LEFT);
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f && currentPoint == pointA.transform)
        {
            ChangeAnimationState(NPC_WALK_RIGHT);
            currentPoint = pointB.transform;
        }
    }

    // Animation state changer
    void ChangeAnimationState(string newState)
    {
        // Stop animation from interrupting itself
        if (currentAnimState == newState) return;
        // Play new animation
        anim.Play(newState);
        // Update current state
        currentAnimState = newState;
    }
}
