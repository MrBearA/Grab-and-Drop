using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;
    private InputManager inputManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = InputManager.Instance;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 input = inputManager.GetMovementInput();
        if (input == Vector3.zero)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0); // Reset horizontal movement
            return;
        }

        Vector3 direction = new Vector3(input.x, 0, input.y).normalized; // Normalize to maintain consistent speed
        Vector3 velocity = direction * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
