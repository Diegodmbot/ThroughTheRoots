using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class CooldownBar : MonoBehaviour {
    private Slider slider;

    public void SetMaxCooldownValue (float maxValue) {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    public void SetCooldown (float currentValue) {
        slider.value = currentValue;
    }

    void Start() {
        slider = GetComponent<Slider>();
    }
}
