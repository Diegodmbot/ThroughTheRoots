using UnityEngine;
using System.Collections;
using System.Threading;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterDash : MonoBehaviour {
  [Tooltip("The cooldown of the dash")]
  [SerializeField] private float dashCooldown = 1f;

  [Tooltip("The power of the dash")]
  [SerializeField] private float dashPower = 24f;

  [Tooltip("The cooldown bar")]
  [SerializeField] private CooldownBar bar;

  /// <value> Whether the character is dashing or not </value>
  private bool isDashing = false;

  /// <value> The time the dash lasts </value>
  private float dashTime = 0.2f;

  /// <value> The rigidbody of the object </value>
  private Rigidbody2D rb;

  /// <value> How much time the character has waited. </value>
  private float currentCooldown = 0f;

  private void Start() {
    bar.SetMaxCooldownValue(dashCooldown);
    rb = GetComponent<Rigidbody2D>();
  }
  /// <summary>
    /// Make the character dash
  /// </summary>
  private IEnumerator Dash() {
    isDashing = true;
    float originalGravity = rb.gravityScale;
    rb.gravityScale = 0;
    rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f); 

    // Wait for the dash to end
    yield return new WaitForSeconds(dashTime);
    rb.gravityScale = originalGravity;
    rb.velocity = Vector2.zero;
    isDashing = false;
  }

  private void Update() {
    currentCooldown -= Time.deltaTime;
    currentCooldown = (currentCooldown <= 0 ? 0 : currentCooldown);
    bar.SetCooldown(dashCooldown - currentCooldown);

    if (!Input.GetKeyDown(KeyCode.LeftShift) || isDashing || currentCooldown > 0) return;

    StartCoroutine(Dash());
    currentCooldown = dashCooldown;
  }

}