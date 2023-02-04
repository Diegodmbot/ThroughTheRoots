using UnityEngine;

public class Health : MonoBehaviour {
  [Tooltip("The maximum amount of points the entity may have")]
  [SerializeField] private int maxHP = 3;

  [Tooltip("The current amount of health points")]
  [SerializeField] private int currentHP = 3;

  /// <summary>
    /// Reset the amount of current of health points
  /// </summary>
  public void resetHP() {
    currentHP = maxHP;
  }

  /// <summary>
    /// Add HP to the current amount of health points
  /// </summary>
  public void restoreHP (int hpRestored) {
    currentHP += hpRestored;
    if (currentHP > maxHP) currentHP = maxHP;
  }

  /// <summary>
    /// Reduce the amount of health points
  /// </summary>
  public void decreaseHP(int damage) {
    currentHP -= damage;
    if (currentHP < 0) currentHP = 0;
  }
}