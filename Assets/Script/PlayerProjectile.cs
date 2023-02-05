using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProjectile : MonoBehaviour {
  public int projectileDamage = 1;
  public LayerMask enemyLayer;

  void OnTriggerEnter2D(Collider2D other) {
    if (other.GetComponent<Health>() != null) {
      Health enemyHealth = other.GetComponent<Health>();
      enemyHealth.decreaseHP(projectileDamage);
    }
    if (other.gameObject.tag != "Player") Destroy(gameObject);
  }

  private IEnumerator DestroyProjectile () {
    yield return new WaitForSeconds(5f);
    Destroy(gameObject);
  }

  void Update() {
    StartCoroutine(DestroyProjectile());
  }
}