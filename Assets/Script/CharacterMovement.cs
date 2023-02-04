using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour {
  [Tooltip("The speed of the character")]
  [SerializeField] private float speed = 4f;

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

  private void Update() {
    Movement();
  }

  private void Start() {
        
  }
}