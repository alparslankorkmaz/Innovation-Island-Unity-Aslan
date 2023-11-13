using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PacmanMovement : MonoBehaviour
{
    public float speed = 8f;
    public float speedMultiplier = 1f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;
    public new Rigidbody2D rigidbody;
    public Vector2 direction;
    public Vector2 nextDirection;
    public Vector3 startingPosition;

    float inputHorizontal;
    float inputVertical;

    bool facingRight = true;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        speedMultiplier = 1f;
        direction = initialDirection;
        nextDirection = Vector2.zero;
        transform.position = startingPosition;
        rigidbody.isKinematic = false;
        enabled = true;
    }

    private void Update()
    {
        // Try to move in the next direction while it's queued to make movements
        // more responsive
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }


        // Rotate pacman to face the movement direction
        // float angle = Mathf.Atan2(inputVertical, inputHorizontal);
        // transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);


    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void FixedUpdate()
    {
        // Vector2 position = rigidbody.position;
        // Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;

        // rigidbody.MovePosition(position + translation);

        inputHorizontal = SimpleInput.GetAxis("Horizontal");
        inputVertical = SimpleInput.GetAxis("Vertical");

        rigidbody.velocity = new Vector2(inputHorizontal, inputVertical) * speed;

        // if (inputHorizontal != 0)
        // {
        //     rigidbody.AddForce(new Vector2(inputHorizontal, inputVertical) * speed);
        // }
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        // Only set the direction if the tile in that direction is available
        // otherwise we set it as the next direction so it'll automatically be
        // set when it does become available
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            nextDirection = Vector2.zero;
        }
        else
        {
            nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        // If no collider is hit then there is no obstacle in that direction
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, obstacleLayer);
        return hit.collider != null;
    }

}
