using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour {
  [Tooltip("The jump force of the character")]
  [SerializeField] private float jumpForce = 6f;

  [Tooltip("How many times the character can jump")]
  [SerializeField] private int maxJumps = 2;

  /// <value> The amount of jumps the character has left </value>
  /// <remarks> This value is reset when the character touches the ground </remarks>
  private int jumpsLeft;

  /// <value> The rigidbody of the object </value>
  private Rigidbody2D rb;

  /// <summary>
    /// Make the character jump
  /// </summary>
  private void Jump() {
    // Add the jump force to the character
    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0) {
      Jump();
      jumpsLeft--;
    }
  }

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
    jumpsLeft = maxJumps;
  }

  private void OnCollisionEnter(Collision other) {
    if (!other.gameObject.CompareTag("Ground")) return;
    jumpsLeft = maxJumps;
  }
}