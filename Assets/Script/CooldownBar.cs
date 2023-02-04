using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class CooldownBar : MonoBehaviour {
    private Slider slider;
    // public Gradient gradient;
    // public Image fill;

    public void SetMaxCooldownValue(float maxValue) {
        slider.maxValue = maxValue;
        slider.value = maxValue;

        // fill.color = gradient.Evaluate(1f);
    }

    public void SetCooldown(float currentValue) {
        slider.value = currentValue;

        // fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Start() {
        slider = GetComponent<Slider>();
    }
}
