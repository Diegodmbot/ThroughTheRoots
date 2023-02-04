using UnityEngine;

public class CharacterMovement : MonoBehaviour {
  [Tooltip("The speed of the character")]
  [SerializeField] private float speed = 4f;

  /// <value> The direction the character is facing </value>
  private bool isFacingRight = true;

  /// <summary>
    /// Move the character in the x-axis
  /// </summary>
  /// <param name="horizontal"> The horizontal input from the player </param>
  private void Movement(float horizontal) {
    // Calculate the direction of the movement
    Vector3 direction = new Vector3(horizontal, 0, 0);

    // Move the character
    transform.position += direction * speed * Time.deltaTime;
  }

  private void Update() {
    // Get the input from the player
    float horizontal = Input.GetAxis("Horizontal");
    Movement(horizontal);

    if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
      Flip();
    }
  }

  /// <summary>
    /// Flip the character
  /// </summary>
  private void Flip() {
    // Get the scale of the character
    Vector3 scale = transform.localScale;

    // Flip the character
    scale.x *= -1;
    isFacingRight = !isFacingRight;

    // Apply the new scale
    transform.localScale = scale;
  }
}