using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{

    public Movement movement { get; private set; }

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        // Set the new direction based on the current input
        if (SimpleInput.GetKeyDown(KeyCode.W) || SimpleInput.GetKeyDown(KeyCode.UpArrow))
        {
            movement.SetDirection(Vector2.up);
        }
        else if (SimpleInput.GetKeyDown(KeyCode.S) || SimpleInput.GetKeyDown(KeyCode.DownArrow))
        {
            movement.SetDirection(Vector2.down);
        }
        else if (SimpleInput.GetKeyDown(KeyCode.A) || SimpleInput.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.SetDirection(Vector2.left);
        }
        else if (SimpleInput.GetKeyDown(KeyCode.D) || SimpleInput.GetKeyDown(KeyCode.RightArrow))
        {
            movement.SetDirection(Vector2.right);
        }

        // Rotate pacman to face the movement direction
        float angle = Mathf.Atan2(movement.direction.y, movement.direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        movement.ResetState();
        gameObject.SetActive(true);
    }


}
