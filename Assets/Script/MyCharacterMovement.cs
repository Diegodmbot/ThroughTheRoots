using UnityEngine;

public class MyCharacterMovement : MonoBehaviour {
  [Tooltip("The speed of the character")]
  [SerializeField] private float speed = 2f;

  [Tooltip("The jump force of the character")]
  [SerializeField] private float jumpForce = 2f;

  [Tooltip("The rigidbody of the character")]
  [SerializeField] private Rigidbody2D rigidbody2D;

  /// <summary>
    /// Move the character in the x-axis
  /// </summary>
  private void Movement() {
    // Get the input from the player
    float horizontal = Input.GetAxis("Horizontal");

    // Calculate the direction of the movement
    Vector3 direction = new Vector3(horizontal, 0, 0);

    // Move the character
    transform.position += direction * speed * Time.deltaTime;
  }

  /// <summary>
    /// Make the character jump
  /// </summary>
  private void Jump() {
    // Add the jump force to the character
    rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
  }

  private void Update() {
    Movement();
    if (Input.GetKeyDown(KeyCode.Space)) Jump();
  }
}