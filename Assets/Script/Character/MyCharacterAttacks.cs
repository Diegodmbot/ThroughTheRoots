using UnityEngine; // UNITY
using System.Collections;
using System.Collections.Generic;

public class MyCharacterAttacks : MonoBehaviour {
  [Tooltip("Attack Hitbox")]
  [SerializeField]private Transform attackPoint;

  [Tooltip("How far the attack can get.")]
  [SerializeField]private float attackRange = 0.5f;

  [Tooltip("Layer of the enemies that can be attacked by the player")]
  [SerializeField]private LayerMask enemyLayers;

  [Tooltip("The time the player has to wait to attack again")]
  [SerializeField] private float attackCooldown = 1.0f;

  [Tooltip("The amount of damage done by the attack")]
  [SerializeField] private int attackDamage = 1;

  // [Tooltip("The cooldown bar")]
  // [SerializeField] private CooldownBar attackCooldownBar;

  /// <value> How much time the player has to wait to attack again. </value>
  private float currentAttackCD = 0;
  public GameObject PlayerProjectile;

  [Tooltip("")]
  [SerializeField] private Animator anim;

  /// <summary>
    /// Execute the melee attack
  /// </summary>
  private void MeleeAttack() {
    anim.SetTrigger("startMeleeAttack");

    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    foreach(Collider2D enemy in hitEnemies) {
      Health enemyHealth = enemy.GetComponent<Health>();
      if (!enemyHealth) continue;
      enemyHealth.decreaseHP(attackDamage);
    }
    currentAttackCD = attackCooldown;
  }

  private IEnumerator throwBall() {
    currentAttackCD = attackCooldown;
    yield return new WaitForSeconds(.3f);

    GameObject newProjectile = Instantiate(PlayerProjectile, attackPoint.position, transform.rotation);
    Vector2 relativeForce = new Vector2(15f * transform.localScale.x, 3f);

    newProjectile.GetComponent<Rigidbody2D>().AddForce(relativeForce, ForceMode2D.Impulse);
  }

  private void RangedAttack() {
    anim.SetTrigger("startRangedAttack");
    StartCoroutine(throwBall());
  }

  void Update() {
    currentAttackCD -= Time.deltaTime;
    currentAttackCD = (currentAttackCD <= 0 ? 0 : currentAttackCD);
    // attackCooldownBar.SetCooldown(attackCooldown - currentAttackCD);

    if (Input.GetKeyDown(KeyCode.J) && currentAttackCD <= 0) {
      MeleeAttack();
    }

    if (Input.GetKeyDown(KeyCode.K) && currentAttackCD <= 0) {
      RangedAttack();
    }
  }

  void Start() {
    // attackCooldownBar.SetMaxCooldownValue(attackCooldown);
  }

  void OnDrawGizmosSelected() {
    if(attackPoint == null) return;
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}