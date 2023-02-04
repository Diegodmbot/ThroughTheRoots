using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterDash : MonoBehaviour {
  private bool canDash;
  private bool isDashing;
  private float dashTime = 0.2f;
  private float dashCooldown = 1f;
  private float dashPower = 24f;

  private Rigidbody2D rb;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  private IEnumerator Dash() {
    canDash = false;
    isDashing = true;
    float originalGravity = rb.gravityScale;
    rb.gravityScale = 0;
    rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f); 

    // Wait for the dash to end
    yield return new WaitForSeconds(dashTime);
    rb.gravityScale = originalGravity;
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
}