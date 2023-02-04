using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : Health {
  [Tooltip("The UI images that represent the health points")]
  [SerializeField] private Image[] imageHearts;

  [Tooltip("Represents a full heart sprite")]
  [SerializeField] private Sprite fullHeart;

  [Tooltip("Represents an empty heart sprite")]
  [SerializeField] private Sprite emptyHeart;

  private void Update() {
    for (int i = 0; i < maxHP; ++i) {
      if (i < currentHP) {
        imageHearts[i].sprite = fullHeart;
      } else {
        imageHearts[i].sprite = emptyHeart;
      }
    }
  }
}