using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterDash : MonoBehaviour {
  [Tooltip("The cooldown of the dash")]
  [SerializeField] private float dashCooldown = 1f;

  [Tooltip("The power of the dash")]
  [SerializeField] private float dashPower = 24f;

  /// <value> Whether the character can dash or not </value>
  private bool canDash = true;

  /// <value> Whether the character is dashing or not </value>
  private bool isDashing = false;

  /// <value> The time the dash lasts </value>
  private float dashTime = 0.2f;

  /// <value> The rigidbody of the object </value>
  private Rigidbody2D rb;

  /// <summary>
    /// Make the character dash
  /// </summary>
  private IEnumerator Dash() {
    canDash = false;
    isDashing = true;
    float originalGravity = rb.gravityScale;
    rb.gravityScale = 0;
    rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f); 

    // Wait for the dash to end
    yield return new WaitForSeconds(dashTime);
    rb.gravityScale = originalGravity;
    rb.velocity = Vector2.zero;
    isDashing = false;

    // Wait for the cooldown to reset the dash
    yield return new WaitForSeconds(dashCooldown);
    canDash = true;
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !isDashing) {
      StartCoroutine(Dash());
    }
  }

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
  }
}