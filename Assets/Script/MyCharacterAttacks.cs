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

  /// <value> How much time the player has to wait to attack again. </value>
  private float currentAttackCD = 0;
  public GameObject PlayerProjectile;

  private void MeleeAttack() {
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    foreach(Collider2D enemy in hitEnemies) {
      Health enemyHealth = enemy.GetComponent<Health>();
      if (!enemyHealth) continue;
      enemyHealth.decreaseHP(attackDamage);
    }
    currentAttackCD = attackCooldown;
  }
  private void RangedAttack() {
    GameObject newProjectile = Instantiate(PlayerProjectile, attackPoint.position, transform.rotation);
    Vector2 relativeForce = new Vector2(15f * transform.localScale.x, 3f);

    newProjectile.GetComponent<Rigidbody2D>().AddForce(relativeForce, ForceMode2D.Impulse);

  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.J) && currentAttackCD <= 0) {
      MeleeAttack();
    }
    if (Input.GetKeyDown(KeyCode.K) && currentAttackCD <= 0) {
      RangedAttack();
    }
    currentAttackCD -= Time.deltaTime;
  }

  void OnDrawGizmosSelected() {
    if(attackPoint == null) return;
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}